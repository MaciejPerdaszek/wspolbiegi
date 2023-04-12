using System.ComponentModel;
using Dane;

namespace Logika
{

    public abstract class LogicAbstractAPI : INotifyPropertyChanged, IDisposable
    {

        public abstract event PropertyChangedEventHandler? PropertyChanged;

        public static LogicAbstractAPI CreateApi()
        {
            return new LogicModel();   
        }

        public abstract void CreateBalls(int amount);

        public abstract void CreateTable(int width, int height);
    
        public abstract List<IBall> GetBallsList();

        public abstract void Dispose();
    }
}
