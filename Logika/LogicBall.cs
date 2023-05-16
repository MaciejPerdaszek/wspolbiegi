using Dane;

namespace Logika
{
    internal class LogicBall : ILogicBall
    {
        private double _diameter;
        private double _mass;
        private Dane.ILogicBall _dataBall;
        private LogicBallChangedEventHandler? _ballChangedEventHandler;

        public double X
        {
            get { return _dataBall.X; }
        }

        public double Y
        {
            get { return _dataBall.Y; }
        }

        public double Diameter { get => _diameter; set => _diameter = value; }

        public double speedX { get => _dataBall.speedX; set => _dataBall.speedX = value; }
        public double speedY { get => _dataBall.speedY; set => _dataBall.speedY = value; }
        public double Mass { get => _mass; set => _mass = value; }
        public int directionX { get => _dataBall.directionX; set => _dataBall.directionX = value; }
        public int directionY { get => _dataBall.directionY; set => _dataBall.directionY = value; }


        public LogicBall(Dane.ILogicBall dataBall, double diameter, double mass)
        {
            _diameter = diameter;
            _mass = mass;
            _dataBall = dataBall;
            dataBall.DataBallChanged += DataBall_DataBallChanged;
        }

        private void DataBall_DataBallChanged(Dane.ILogicBall sender)
        {
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

            if (distance <= Diameter)
            {
                    lock (LogicModel.collisionLock)
                    {
                        double nx = dx / distance;
                        double ny = dy / distance;

                        double dvx = other.speedX - speedX;
                        double dvy = other.speedY - speedY;

                        double prod = dvx * nx + dvy * ny;

                        double impulse = 2 * Mass * other.Mass * prod / ((Mass + other.Mass) * distance);

                        double changeX = impulse * nx / Mass;
                        double changeY = impulse * ny / Mass;

                        speedX += changeX;
                        speedY += changeY;
                        other.speedX -= changeX;
                        other.speedY -= changeY;

                       
                         if (directionX != other.directionX)
                         {
                             directionX *= -1;
                             other.directionX *= -1;
                         }
                         if (directionY != other.directionY)
                         {
                             directionY *= -1;
                             other.directionY *= -1;
                         }

                        // omijanie nakladania sie kuli
                        double overlap = 0.8 * (distance - Diameter);
                        double avoidX = overlap * nx;
                        double avoidY = overlap * ny;

                        speedX -= avoidX / Mass;
                        speedY -= avoidY / Mass;
                        other.speedX += avoidX / other.Mass;
                        other.speedY += avoidY / other.Mass;
                }
            }
        }
    }
}
