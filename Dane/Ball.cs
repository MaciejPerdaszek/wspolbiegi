using System.Numerics;

namespace Dane
{
    internal class Ball : IDataBall
    {
        private readonly int _id;

        private double _speedX;
        private double _speedY;

        private int _directionX;
        private int _directionY;

        private Vector2 _vector;

        public Ball(float x, float y, int id)
        {
            _id = id;

            Random random = new Random();
            _speedX = random.Next(2) * 10 - 5; ;
            _speedY = random.Next(2) * 10 - 5; ;
            _directionX = random.Next(2) * 2 - 1;
            _directionY = random.Next(2) * 2 - 1;

            _vector = new Vector2(x, y);
            OnBallChangedEvent();
            Move();
        }
   

        internal float X
        {
            get
            {
                return _vector.X;
            }
            set
            {
                _vector.X = value;
                OnBallChangedEvent();
            }
        }

        internal float Y
        {
            get
            {
                return _vector.Y;
            }
            set
            {
                _vector.Y = value;
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
        private async Task Move()
        {
            while(true)
            {
                _vector.X += (float) _speedX;
                _vector.Y += (float) _speedY;
                OnBallChangedEvent();
                await Task.Delay(17);
            }
        }

        private void OnBallChangedEvent()
        {
            DataBallChanged?.Invoke(this, _vector);
        }
    }
}