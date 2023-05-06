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
        private double _mass;

        private int _directionX;
        private int _directionY;

        public Ball(double x, double y)
        {
            this._x = x;
            this._y = y;
            _speedTimerX = new Timer(MoveX, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
            _speedTimerY = new Timer(MoveY, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
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
                _speedTimerX.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(value));
            } 
        }
        public double speedY
        {
            get => _speedY;
            set
            {
                _speedY = value;
                _speedTimerY.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(value));
            }
        }
        public int directionX { get => _directionX; set => _directionX = value; }
        public int directionY { get => _directionY; set => _directionY = value; }
        public double Mass { get => _mass; set => _mass = value; }

        public event DataBallChangedEventHandler DataBallChanged;

        public void Dispose()
        {
            _speedTimerX.Dispose();
            _speedTimerY.Dispose();
        }

        private void MoveX(object? state)
        {
            if (state != null)
                throw new ArgumentOutOfRangeException("state");
            X += directionX;
        }

        private void MoveY(object? state)
        {
            if (state != null)
                throw new ArgumentOutOfRangeException("state");
            Y += directionY;
        }

        private void OnBallChangedEvent()
        {
            DataBallChanged?.Invoke(this);
        }
    }
}