using Dane;

namespace Logika
{
    internal class LogicModel : LogicAbstractAPI
    {
        private readonly DataAbstractAPI DataApi;

        private int _width;
        private int _height;


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

        private void Ball_LogicBallChanged(ILogicBall sender)
        {
            LogicBall ball = (LogicBall)sender;
            if (ball.X > width || ball.X < 0) ball.directionX = ball.directionX * -1;

            if (ball.Y > height || ball.Y < 0) ball.directionY = ball.directionY * -1;
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
                }
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
