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
            IDisposable observer = DataApi.Subscribe(x => Balls.Add(x));
        }

        public ObservableCollection<IBall> Balls { get; } = new ObservableCollection<IBall>();

        public override void CreateBalls(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Random r = new();
                double x = r.NextDouble() * 10;
                double y = r.NextDouble() * 10;
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
