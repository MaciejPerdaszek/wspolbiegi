using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    internal class Ball : IBall, INotifyPropertyChanged
    {
        private double _x;
        private double _y;
        private Timer _timer;
        private Random _random = new();

        public Ball(double x, double y)
        {
            this._x = x;
            this._y = y;
            this._timer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
        }

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                PropertyChangedEvent("X");

            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                PropertyChangedEvent("Y");

            }
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        public void Move(object? state)
        {
            if (state != null)
                throw new ArgumentOutOfRangeException("state");
            X += _random.NextDouble() * 80 - 40;
            Y += _random.NextDouble() * 80 - 40;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void PropertyChangedEvent([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}