using System.Collections.ObjectModel;
using System.ComponentModel;
using Dane;

namespace Logika
{

    public abstract class LogicAbstractAPI : IDisposable
    {
        public static LogicAbstractAPI CreateApi()
        {
            return new LogicModel();   
        }

        public abstract void CreateBalls(int amount);

        public abstract ObservableCollection<IBall>? Balls { get; }

        #region IDisposable

        public abstract void Dispose();

        #endregion IDisposable
    }
}
