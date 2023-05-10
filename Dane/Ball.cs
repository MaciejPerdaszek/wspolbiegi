using System.Diagnostics;

namespace Dane
{
    internal class Ball : IBall
    {
        private double _x;
        private double _y;
        private Timer _speedTimerX;
        private Timer _speedTimerY;

        private double _speedX;
        private double _speedY;

        private int _directionX;
        private int _directionY;

        public Ball(double x, double y)
        {
            this._x = x;
            this._y = y;
            Random random = new Random();
            _speedX = random.NextDouble() * 200;
            _speedY = random.NextDouble() * 200;
            _directionX = random.Next(2) * 2 - 1;
            _directionY = random.Next(2) * 2 - 1;
            Move();
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
                OnBallChangedEvent();
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
                OnBallChangedEvent();
            }
        }

        public double speedX { 
            get => _speedX; 
            set 
            { 
                _speedX = value;
            } 
        }
        public double speedY
        {
            get => _speedY;
            set
            {
                _speedY = value;
            }
        }
        public int directionX
        {
            get
            {
               return _directionX;
            }
            set
            {
                _directionX = value;
            }
        }
        public int directionY { get => _directionY; set => _directionY = value; }

        public event DataBallChangedEventHandler DataBallChanged;

        public void Dispose()
        {
            _speedTimerX.Dispose();
            _speedTimerY.Dispose();
        }

        private void Move()
        {
            Task t1 = Task.Run(() =>
                {
                    while (true)
                    {
                        X += directionX;
                        Thread.Sleep(TimeSpan.FromMilliseconds(speedX * 0.5));
                    }
                });
            Task t2 = Task.Run(() =>
            {
                while (true)
                {
                    Y += directionY;
                    Thread.Sleep(TimeSpan.FromMilliseconds(speedY * 0.5));
                }
            });



        }

        private void OnBallChangedEvent()
        {
            DataBallChanged?.Invoke(this);
        }
    }
}