namespace Dane
{
    internal class Ball : IDataBall
    {
        private readonly int _id;

        private double _x;
        private double _y;

        private double _speedX;
        private double _speedY;

        private int _directionX;
        private int _directionY;

        public Ball(double x, double y, int id)
        {
            _x = x;
            _y = y;
            _id = id;


            Random random = new Random();
            _speedX = random.NextDouble() * 200;
            _speedY = random.NextDouble() * 200;
            _directionX = random.Next(2) * 2 - 1;
            _directionY = random.Next(2) * 2 - 1;

            Move();
        }
   

        internal double X
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

        internal double Y
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

        public int Id
        {
            get
            {
                return _id;
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

        public event DataBallChangedEventHandler? DataBallChanged;

        public void Dispose()
        {
            
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
            DataBallChanged?.Invoke(this, X, Y);
        }
    }
}