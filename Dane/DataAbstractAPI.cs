using System.ComponentModel;

namespace Dane
{
    public interface IBall : INotifyPropertyChanged, IDisposable
    {
        double X { get; set; }
        double Y { get; set; }
    }

    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI CreateApi()
        {
            return new DataModel();   
        }

        public abstract IBall CreateBall(double x, double y);

    }
}
