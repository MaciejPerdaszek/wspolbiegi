using System.Collections.Generic;
using Logika;

namespace Prezentacja.Model
{
    public class Model : ModelAbstractAPI
    {
        private readonly LogicAbstractAPI LogicApi;

        private int _ballsCounter = 0;

        public Model()
        {
            LogicApi = LogicAbstractAPI.CreateApi();
        }

        public override void CreateBalls(int amount, double radius, double mass)
        {
            LogicApi.CreateBalls(amount, radius, mass);
            _ballsCounter += amount;
        }

        public override int getBallsCount()
        {
            return _ballsCounter;
        }

        public override List<IViewBall> GetViewBalls()
        {
            return viewBallsList;
        }

        public override void Dispose()
        {
            LogicApi.Dispose();
        }

        public override void CreateTable(int width, int height)
        {
            LogicApi.CreateTable(width, height);
        }
    }
}

