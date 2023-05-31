
using System.Numerics;

namespace Logika
{
    internal class LogicBall : ILogicBall
    {
        private double _diameter;
        private double _mass;
        private Dane.IDataBall _dataBall;
        private LogicBallChangedEventHandler? _ballChangedEventHandler;

        private double _x;
        private double _y;

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Diameter { get => _diameter; set => _diameter = value; }

        public double speedX { get => _dataBall.speedX; set => _dataBall.speedX = value; }
        public double speedY { get => _dataBall.speedY; set => _dataBall.speedY = value; }
        public double Mass { get => _mass; set => _mass = value; }
        public int directionX { get => _dataBall.directionX; set => _dataBall.directionX = value; }
        public int directionY { get => _dataBall.directionY; set => _dataBall.directionY = value; }


        public LogicBall(Dane.IDataBall dataBall, double diameter, double mass)
        {
            _diameter = diameter;
            _mass = mass;
            _dataBall = dataBall;
            dataBall.DataBallChanged += DataBall_DataBallChanged;
        }

        private void DataBall_DataBallChanged(Dane.IDataBall sender, Vector2 vector)
        {
            X = vector.X;
            Y = vector.Y;
            OnBallChangedEvent();
        }

        private void OnBallChangedEvent()
        {
            _ballChangedEventHandler?.Invoke(this);
        }

        public event LogicBallChangedEventHandler LogicBallChanged
        {
            add
            {
                _ballChangedEventHandler += value;
            }
            remove
            {
                _ballChangedEventHandler -= value;
            }
        }

        public void Dispose()
        {
            _dataBall.Dispose();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
        public void Collide(ILogicBall other)
        {
            double dx = other.X - X;
            double dy = other.Y - Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance <= Diameter && ((speedX - other.speedX) * (other.X - X) + (speedY - other.speedY) * (other.Y - Y) >= 0))
            {
                double v1x = (speedX * (Mass - other.Mass) + 2 * other.Mass * other.speedX)/(Mass + other.Mass);
                double v1y = (speedY * (Mass - other.Mass) + 2 * other.Mass * other.speedY) / (Mass + other.Mass);

                double v2x = (other.speedX * (other.Mass - Mass) + 2 * Mass * speedX) / (Mass + other.Mass);
                double v2y = (other.speedY * (other.Mass - Mass) + 2 * Mass * speedY) / (Mass + other.Mass);

                speedX = v1x;
                speedY = v1y;
                other.speedX = v2x;
                other.speedY = v2y;
            }
        }
    }
}
