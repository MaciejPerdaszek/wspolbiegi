using System.Diagnostics;
using System.Xml.Serialization;

namespace Dane
{

    internal class DataModel : DataAbstractAPI
    {
        private static int ballNumber = 0;
        public override IDataBall CreateBall(double x, double y)
        {
            ballNumber++;
            
            Ball newBall = new(x,y, ballNumber);
            newBall.DataBallChanged += NewBall_DataBallChanged;

            return newBall;
        }
        private void NewBall_DataBallChanged(IDataBall sender, double x, double y)
        {
            lock (diagnosticFileLock)
            {
                addRecord(sender.Id, x, y, DateTime.Now);
            }
        }

        [XmlArray]
        public static List<BallRecord> Records { get; set; } = new List<BallRecord>();

        public static object diagnosticFileLock = new();
        public static String diagnosticFileName = "ball-data-"+DateTime.Now.Ticks+".xml";
        private void addRecord(int id, double x, double y, DateTime timestamp)
        {
            BallRecord record = new(id, x, y, timestamp);
            Records.Add(record);
            XmlSerializer xmlSerializer = new(Records.GetType());
            try
            {
                using (StreamWriter streamWriter = File.CreateText(diagnosticFileName))
                {
                    xmlSerializer.Serialize(streamWriter, Records);
                }
            }
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine("File error: " + ex.Message);
            }
        }
    }
    public class BallRecord
    {
        public BallRecord(int id, double x, double y, DateTime timestamp)
        {
            Timestamp = timestamp;
            Id = id;
            X = x;
            Y = y;
        }

        public BallRecord() { }

        public DateTime Timestamp { get; set; }

        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
