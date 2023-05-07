using Dane;
using System.ComponentModel;

namespace Logika
{

    public delegate void LogicBallChangedEventHandler(ILogicBall sender);
    public interface ILogicBall : IDisposable
    {
        double X { get; }
        double Y { get; }
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

        public abstract void CreateBalls(int amount, double diameter, double mass);

        public abstract void CreateTable(int width, int height);

        public abstract void Dispose();
    }
}
