using System.Xml.Serialization;

namespace Dane
{

    internal class DataModel : DataAbstractAPI
    {
        [XmlArray]
        public static List<BallRecord> Records { get; set; } = new List<BallRecord>();

        [XmlArray]
        public static List<BallRecord> AllRecords { get; set; } = new List<BallRecord>();

        public static object diagnosticFileLock = new();
        public static String diagnosticFileName = "ball-data-"+DateTime.Now.Ticks+".xml";

        private static int ballNumber = 0;

        private static bool record = false;
        

        public static void addRecord(Ball ball)
        {
            lock (diagnosticFileLock)
            {
                BallRecord br = Records.Find(r => r.Id == ball.Id);
            if(br == null && record)
            {
                BallRecord record = new(DateTime.Now, ball.Id, ball.X, ball.Y, ball.speedX, ball.speedY, ball.directionX, ball.directionY);
                Records.Add(record);
                    
                }
                if (Records.Count() == ballNumber)
                {
                    AllRecords.AddRange(Records);

                    XmlSerializer xmlSerializer = new(AllRecords.GetType());

                    using (StreamWriter streamWriter = File.CreateText(diagnosticFileName))
                    {
                        xmlSerializer.Serialize(streamWriter, AllRecords);
                        record = false;
                        Records.Clear();
                    }
                }
            }
        }

        public override void SaveRecord()
        {
           
            Records.Clear();
            record = true;
        }

        public DataModel() {

        }

        public override IDataBall CreateBall(double x, double y)
        {
            ballNumber++;
            
            Ball newBall = new(x,y, ballNumber);

            return newBall;
        }
    }
    public class BallRecord
    {
        public BallRecord(DateTime timestamp, int id, double x, double y, double speedX, double speedY, int directionX, int directionY)
        {
            Timestamp = timestamp;
            Id = id;
            X = x;
            Y = y;
            this.directionX = directionX;
            this.directionY = directionY;
            this.speedX = speedX;
            this.speedY = speedY;
        }

        public BallRecord() { }

        public DateTime Timestamp { get; set; }

        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double speedX { get; set; }
        public double speedY { get; set; }
        public int directionX { get; set; }
        public int directionY { get; set; }
    }
}
