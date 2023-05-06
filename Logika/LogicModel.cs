using Dane;
using System.Xml.Serialization;

namespace Logika
{
    internal class LogicModel : LogicAbstractAPI
    {
        private readonly DataAbstractAPI DataApi;

        private int _width;
        private int _height;
        private List<ILogicBall> _balls = new List<ILogicBall>();

        public int width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        public LogicModel() { 
            DataApi = DataAbstractAPI.CreateApi();
        }

        public override void CreateTable(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public override void CreateBalls(int amount, double diameter)
        {
            if (width != 0 && height != 0)
                for (int i = 0; i < amount; i++)
                {
                    Random r = new();
                    double x = r.NextDouble() * 500;
                    double y = r.NextDouble() * 300;
                    ILogicBall ball = new LogicBall(DataApi.CreateBall(x, y), diameter);
                    ball.LogicBallChanged += Ball_LogicBallChanged;
                    _balls.Add(ball);
                }
        }

        private void Ball_LogicBallChanged(ILogicBall sender)
        {
            LogicBall ball = (LogicBall)sender;
            if (ball.X > width || ball.X < 0) ball.directionX = ball.directionX * -1;

            if (ball.Y > height || ball.Y < 0) ball.directionY = ball.directionY * -1;

            CheckCollisions();
        }
       
        private void CheckCollisions()
        {
            for (int i = 0; i < _balls.Count; i++)
            {
                for(int j = i + 1 ;j < _balls.Count; j++)
                {
                    double distance = Math.Sqrt(Math.Pow(_balls[i].X - _balls[j].Y, 2) + Math.Pow(_balls[i].X - _balls[j].Y, 2));
                    double sumDiameter = _balls[i].Diameter + _balls[j].Diameter;
                    if (distance <= sumDiameter) 
                    {
                        CollisionDetected(_balls[i], _balls[j]);
                    }
                }
            }
        }

        private void CollisionDetected(ILogicBall ball1, ILogicBall ball2)
        {
            //wzory na zderzenia sprężyste 
            double dx = ball2.X - ball1.X;
            double dy = ball2.Y - ball1.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            double nx = dx / distance; 
            double ny = dy / distance;

            double tx = -ny; 
            double ty = nx;

            double v1x = ball1.speedX * ball1.directionX;
            double v1y = ball1.speedY * ball1.directionY;
            double v2x = ball2.speedX * ball2.directionX;
            double v2y = ball2.speedY * ball2.directionY;

            double v1n = nx * v1x + ny * v1y;
            double v1t = tx * v1x + ty * v1y;
            double v2n = nx * v2x + ny * v2y;
            double v2t = tx * v2x + ty * v2y;

            double m1 = ball1.Mass;
            double m2 = ball2.Mass;
            double v1n_new = (v1n * (m1 - m2) + 2 * m2 * v2n) / (m1 + m2);
            double v2n_new = (v2n * (m2 - m1) + 2 * m1 * v1n) / (m1 + m2);

            double v1x_new = v1n_new * nx + v1t * tx;
            double v1y_new = v1n_new * ny + v1t * ty;
            double v2x_new = v2n_new * nx + v2t * tx;
            double v2y_new = v2n_new * ny + v2t * ty;

            ball1.directionX = Math.Sign(v1x_new);
            ball1.directionY = Math.Sign(v1y_new);
            ball1.speedX = Math.Abs(v1x_new);
            ball1.speedY = Math.Abs(v1y_new);

            ball2.directionX = Math.Sign(v2x_new);
            ball2.directionY = Math.Sign(v2y_new);
            ball2.speedX = Math.Abs(v2x_new);
            ball2.speedY = Math.Abs(v2y_new);
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
