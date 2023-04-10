using Dane;
using System.Collections.ObjectModel;

namespace Logika
{
    public class LogicModel : LogicAbstractAPI
    {
        #region private

        private readonly DataAbstractAPI DataApi;

        #endregion private

        #region public API
        public LogicModel() { 
            DataApi = DataAbstractAPI.CreateApi();
            Border border = new(600, 400);
            IDisposable observer = DataApi.Subscribe(ball =>
            {
                Balls.Add(ball);

                if (ball.X > border.Width) ball.X = border.Width;
                else if (ball.X < 0) ball.X = 0;

                if (ball.Y > border.Height) ball.Y = border.Height;
                else if (ball.Y < 0) ball.Y = 0;
            }
            );
        }

        public override ObservableCollection<IBall> Balls { get; } = new ObservableCollection<IBall>();

        public override void CreateBalls(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Random r = new();
                double x = r.NextDouble() * 600;
                double y = r.NextDouble() * 400;
                DataApi.CreateBall(x, y);
            }
        }

        #endregion public API

        #region IDisposable

        public override void Dispose()
        {
            DataApi.Dispose();
        }

        #endregion
    }
}
