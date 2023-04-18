using Dane;
using System.ComponentModel;

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

        private void Ball_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != null)
            {
                LogicBall ball = (LogicBall)sender;
                if (ball.X > width) ball.X = width;
                else if (ball.X < 0) ball.X = 0;

                if (ball.Y > height) ball.Y = height;
                else if (ball.Y < 0) ball.Y = 0;
            }
        }
        public override void CreateTable(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public override List<ILogicBall> CreateBalls(int amount, double diameter)
        {
            List<ILogicBall> list = new();
            if (width != 0 && height != 0)
                for (int i = 0; i < amount; i++)
                {
                    Random r = new();
                    double x = r.NextDouble() * 500;
                    double y = r.NextDouble() * 300;
                    ILogicBall ball = new LogicBall(DataApi.CreateBall(x, y), diameter);
                    ball.PropertyChanged += Ball_PropertyChanged;
                    list.Add(ball);
                }
            return list;
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
