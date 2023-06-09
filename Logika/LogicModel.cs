﻿using Dane;

namespace Logika
{
    internal class LogicModel : LogicAbstractAPI
    {
        private readonly DataAbstractAPI DataApi;

        private int _width;
        private int _height;
        private List<ILogicBall> _balls = new List<ILogicBall>();

        public static readonly object collisionLock = new object();

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

        public override ILogicBall CreateBall(double diameter, double mass)
        {
            if (width != 0 && height != 0)
               {
                    Random r = new();
                    double x = diameter + r.NextDouble() * (_width - diameter);
                    double y = diameter + r.NextDouble() * (_height - diameter);
                    ILogicBall ball = new LogicBall(DataApi.CreateBall((float) x, (float) y), diameter, mass);
                    ball.LogicBallChanged += Ball_LogicBallChanged;
                    _balls.Add(ball);
                    return ball;
               }
            throw new Exception("Table not initialized");
        }

        private void Ball_LogicBallChanged(ILogicBall b)
        {

            LogicBall ball = (LogicBall) b;

            if (ball.X > width)
                ball.speedX = -Math.Abs(ball.speedX);
            else if (ball.X < 0)
                ball.speedX = Math.Abs(ball.speedX);

            if (ball.Y > height)
                ball.speedY = -Math.Abs(ball.speedY);
            else if (ball.Y < 0)
                ball.speedY = Math.Abs(ball.speedY);

            foreach (ILogicBall other in _balls)
            {
                lock (collisionLock)
                {
                    if (ball == other)
                        continue;
                
                    ball.Collide(other);
                }
            }
        }    
    
        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
