using Logika;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        private int _id;

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


        public double Diameter { get => _diameter; set => _diameter = value; }

        public int id { get => _id; set => _id = value; }

        public ViewBall(ILogicBall logicBall)
        {
            _x = logicBall.X;
            _y = logicBall.Y;
            _diameter = logicBall.Diameter;
            _logicBall = logicBall;
            logicBall.LogicBallChanged += LogicBall_LogicBallChanged;
        }

        private void LogicBall_LogicBallChanged(ILogicBall sender)
        {
            _realX = _logicBall.X;
            _realY = _logicBall.Y;
        }

        /*private void OnTimerTick(object? sender, EventArgs e)
        {
            var dx = _realX - X;
            var dy = _realY - Y;

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
                    X = _realX;
                    Y = _realY;
                }
            }
        }*/


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
