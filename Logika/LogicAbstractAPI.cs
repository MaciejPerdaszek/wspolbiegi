using System.ComponentModel;
using Dane;

namespace Logika
{
    public interface ILogicBall : INotifyPropertyChanged, IDisposable
    {
        double X { get; set; }
        double Y { get; set; }
        double Diameter { get; set; }
    }
    public abstract class LogicAbstractAPI : IDisposable
    {
        public static LogicAbstractAPI CreateApi()
        {
            return new LogicModel();   
        }

        public abstract List<ILogicBall> CreateBalls(int amount, int radius);

        public abstract void CreateTable(int width, int height);

        public abstract void Dispose();
    }
}
