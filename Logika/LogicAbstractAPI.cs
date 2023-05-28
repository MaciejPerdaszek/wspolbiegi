namespace Logika
{

    public delegate void LogicBallChangedEventHandler(ILogicBall sender);
    public interface ILogicBall : IDisposable
    {
        double X { get; internal set; }
        double Y { get; internal set; }
        double speedX { get; internal set; }
        double speedY { get; internal set; }
        int directionX { get; internal set; }
        int directionY { get; internal set; }
        double Mass { get; internal set; }  
        double Diameter { get; internal set; }

        event LogicBallChangedEventHandler LogicBallChanged;
  
    }

    public abstract class LogicAbstractAPI : IDisposable
    {
        public static LogicAbstractAPI CreateApi()
        {
            return new LogicModel();   
        }

        public abstract ILogicBall CreateBall(double diameter, double mass);

        public abstract void CreateTable(int width, int height);

        public abstract void SaveRecord();

        public abstract void Dispose();
    }
}
