using Dane;

namespace Logika
{
    internal class LogicBall : ILogicBall
    {
        private double _diameter;
        private IBall _dataBall;

        public event LogicBallChangedEventHandler? ballChangedEventHandler;

        public double X
        {
            get { return _dataBall.X; }
            //set { /*_dataBall.X = value;*/ OnBallChangedEvent(); }
        }

        public double Y
        {
            get { return _dataBall.Y; }
            //set {/* _dataBall.Y = value; */OnBallChangedEvent(); }
        }

        public double Diameter { get => _diameter; set => _diameter = value; }

        public double speedX { get => _dataBall.speedX; set => _dataBall.speedX = value; }
        public double speedY { get => _dataBall.speedY; set => _dataBall.speedY = value; }
        public double Mass { get => _dataBall.Mass; set => _dataBall.Mass = value; }    
        public int directionX { get => _dataBall.directionX; set => _dataBall.directionX = value; }
        public int directionY { get => _dataBall.directionY; set => _dataBall.directionY = value; }


        public LogicBall(IBall dataBall, double diameter)
        {
            _diameter = diameter;
            _dataBall = dataBall;
            dataBall.DataBallChanged += DataBall_DataBallChanged;
        }

        private void DataBall_DataBallChanged(IBall sender)
        {
            OnBallChangedEvent();
        }

        private void OnBallChangedEvent()
        {
            ballChangedEventHandler?.Invoke(this);
        }

        public void Dispose()
        {
            _dataBall.Dispose();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
