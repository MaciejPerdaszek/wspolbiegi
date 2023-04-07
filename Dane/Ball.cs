using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    public class Ball : IBall
    {
        #region private

        private double x;
        private double y;
        private Timer timer;
        private Random random = new();

        private void PropertyChangedEvent([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }

        #endregion private

        public Ball(double x, double y) 
        { 
            this.x = x; 
            this.y = y;
            this.timer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
        }

        #region IBall
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                if (x == value)
                    return;

                x = value;
                PropertyChangedEvent();
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            public set
            {
                if (y == value)
                    return;

                y = value;
                PropertyChangedEvent();
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion INotifyPropertyChanged
        #endregion IBall

        #region IDisposable
        public void Dispose()
        {
            timer.Dispose();
        }
        #endregion IDisposable

        public void Move(object? state)
        {
            if (state != null)
                throw new ArgumentOutOfRangeException("state");
            x += x + random.NextDouble() * 2 - 1;
            y += y + random.NextDouble() * 2 - 1;
        }   

    }
}