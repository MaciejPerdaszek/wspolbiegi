using Dane;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        public override void CreateBalls(int amount)
        {
            if(width != 0 && height != 0)
                for (int i = 0; i < amount; i++)
                {
                    Random r = new();
                    double x = r.NextDouble() * 600;
                    double y = r.NextDouble() * 400;
                    IBall ball = DataApi.CreateBall(x, y);
                    ball.PropertyChanged += Ball_PropertyChanged;
                }
        }
        public override List<IBall> GetBallsList()
        {
            return DataApi.GetBallsList();
        }
        private void Ball_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (sender != null)
            {
                    IBall ball = (IBall) sender;
                    if (ball.X > width) ball.X = width;
                    else if (ball.X < 0) ball.X = 0;

                    if (ball.Y > height) ball.Y = height;
                    else if (ball.Y < 0) ball.Y = 0;
            }
        }

        public override event PropertyChangedEventHandler? PropertyChanged;

        public override void Dispose()
        {
            DataApi.Dispose();
        }

        public override void CreateTable(int width, int height)
        {
            _width = width;
            _height = height;
        }
    }
}
