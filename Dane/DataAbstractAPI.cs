using System.ComponentModel;

namespace Dane
{
    public interface IBall : INotifyPropertyChanged, IDisposable
    {
        double X { get; set; }
        double Y { get; set; }
    }

    public class BallChangedEventArgs : EventArgs
    {
        public IBall? Ball { get; internal set; }
    }

    public abstract class DataAbstractAPI : IObservable<IBall>, IDisposable
    {
        public static DataAbstractAPI CreateApi()
        {
            return new DataModel();   
        }

        public abstract void CreateBall(double x, double y);


        #region IObservable

        public abstract IDisposable Subscribe(IObserver<IBall> observer);

        #endregion IObservable

        #region IDisposable

        public abstract void Dispose();

        #endregion IDisposable

        #region API

        public abstract event EventHandler<BallChangedEventArgs>? BallChangedEvent;

        #endregion API
    }
}
