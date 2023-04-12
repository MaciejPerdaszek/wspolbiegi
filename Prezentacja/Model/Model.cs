using System.Collections.Generic;
using Dane;
using Logika;

namespace Prezentacja.Model
{
    public class Model : ModelAbstractAPI
    {
        private readonly LogicAbstractAPI LogicApi;

        private List<IViewBall> _viewBallsList = new();

        public Model()
        {
            LogicApi = LogicAbstractAPI.CreateApi();
        }

        public override void CreateBalls(int amount, int radius)
        {
            foreach(ILogicBall logicBall in LogicApi.CreateBalls(amount, radius))
            {
                _viewBallsList.Add(new ViewBall(logicBall));
            }
        }

        public override List<IViewBall> GetViewBalls()
        {
            return _viewBallsList;
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

