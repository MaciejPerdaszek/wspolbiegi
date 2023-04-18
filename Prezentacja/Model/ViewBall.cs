using Logika;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace Prezentacja.Model
{
    public class ViewBall : IViewBall
    {
        private double _x;
        private double _y;
        private double _realX;
        private double _realY;
        private double _diameter;
        private ILogicBall _logicBall;
        private DispatcherTimer _timer;

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                OnPropertyChanged("X");
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
                OnPropertyChanged("Y");
            }
        }

        public double realX
        {
            get
            {
                return _realX;
            }
            set
            {
                _realX = value;
            }
        }

        public double realY
        {
            get
            {
                return _realY;
            }
            set
            {
                _realY = value;
            }
        }


        public double diameter { get => _diameter; set => _diameter = value; }

        public ViewBall(ILogicBall logicBall)
        {
            _x = logicBall.X;
            _y = logicBall.Y;
            _diameter = logicBall.Diameter;
            _logicBall = logicBall;
            logicBall.PropertyChanged += LogicBall_PropertyChanged;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(10); 
            _timer.Tick += OnTimerTick;
            _timer.Start();
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            var dx = realX - X;
            var dy = realY - Y;

            if (dx != 0 || dy != 0)
            {
                double step = 0.5;
                var distance = Math.Sqrt(dx * dx + dy * dy);
                if (distance > step)
                {
                    var ratio = step / distance;
                    X += dx * ratio;
                    Y += dy * ratio;
                }
                else
                {
                    X = realX;
                    Y = realY;
                }
            }
        }

            private void LogicBall_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "X")
            {
                realX = _logicBall.X;
            }

            if (e.PropertyName == "Y")
            {
                realY = _logicBall.Y;
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void Dispose()
        {
            _logicBall.Dispose();
        }
    }
}
