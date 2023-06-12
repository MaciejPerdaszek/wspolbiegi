using System.Collections.Concurrent;
using System.Numerics;
using System.Xml;

namespace Dane
{

    internal class DataModel : DataAbstractAPI
    {
        private static int ballNumber = 0;
        public override IDataBall CreateBall(float x, float y)
        {
            ballNumber++;

            Ball newBall = new(x, y, ballNumber);
            newBall.DataBallChanged += NewBall_DataBallChanged;

            return newBall;
        }

        public static object diagnosticFileLock = new();
        private void NewBall_DataBallChanged(IDataBall sender, Vector2 vector)
        {
            lock (diagnosticFileLock)
            {
                recordQueue.Enqueue(new BallRecord(sender.Id, vector, DateTime.Now));
            }
        }

        public DataModel()
        {
            BallRecordReader ballRecordReader = new();
            ballRecordReader.Run();
        }

        public static ConcurrentQueue<BallRecord> recordQueue = new();
    }

    internal class BallRecordReader
    {
        string diagnosticFileName;

        public BallRecordReader()
        {
            diagnosticFileName = "ball-records-" + DateTime.Now.Ticks + ".xml";
            XmlDocument xmlDoc = new();
            XmlElement rootElement = xmlDoc.CreateElement("BallRecords");
            xmlDoc.AppendChild(rootElement);
            xmlDoc.Save(diagnosticFileName);
        }
        public async Task Run()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    if (DataModel.recordQueue.TryDequeue(out var record))
                    {
                        XmlDocument xmlDoc = new();
                        xmlDoc.Load(diagnosticFileName);
                        XmlElement rootElement = xmlDoc.DocumentElement;

                        XmlElement recordElement = xmlDoc.CreateElement("record");
                        recordElement.SetAttribute("id", record.Id.ToString());
                        recordElement.SetAttribute("timestamp", record.Timestamp.Hour.ToString()+":"+record.Timestamp.Minute.ToString()+":"+record.Timestamp.Second.ToString()+":"+record.Timestamp.Millisecond.ToString());

                        XmlElement xElement = xmlDoc.CreateElement("X");
                        xElement.InnerText = record.X.ToString();
                        recordElement.AppendChild(xElement);

                        XmlElement yElement = xmlDoc.CreateElement("Y");
                        yElement.InnerText = record.Y.ToString();
                        recordElement.AppendChild(yElement);

                        rootElement.AppendChild(recordElement);
                        xmlDoc.Save(diagnosticFileName);
                    }
                }
            });
        }
    }

    public class BallRecord
    {
        public BallRecord(int id, Vector2 vector, DateTime timestamp)
        {
            Timestamp = timestamp;
            Id = id;
            X = vector.X;
            Y = vector.Y;
        }

        public BallRecord() { }

        public DateTime Timestamp { get; set; }

        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
}
