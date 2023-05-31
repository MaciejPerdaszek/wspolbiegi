using System.Collections.Concurrent;
using System.Numerics;
using System.Xml.Serialization;

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
            BallRecordReader.Run();
        }

        public static ConcurrentQueue<BallRecord> recordQueue = new();
    }

    internal class BallRecordReader 
    {
        static String diagnosticFileName = "ball-data-" + DateTime.Now.Ticks + ".xml";
        static List<BallRecord> records = new();
        static XmlSerializer xmlSerializer = new(typeof(List<BallRecord>));
        static public async Task Run()
        {
            await Task.Run(() => {
                while (true) {
                    if (DataModel.recordQueue.TryDequeue(out BallRecord record))
                    {
                        using(StreamWriter streamWriter = File.CreateText(diagnosticFileName)) { 
                            records.Add(record);
                            xmlSerializer.Serialize(streamWriter, records);
                        }
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
