using System.Collections.Generic;
using Dane;
using Logika;

namespace Prezentacja.Model
{
    public class Model : ModelAbstractAPI
    {
        private readonly LogicAbstractAPI LogicApi;

       

        public Model()
        {
            LogicApi = LogicAbstractAPI.CreateApi();
        }

        public override void CreateBalls(int amount, int radius)
        {
            foreach(ILogicBall logicBall in LogicApi.CreateBalls(amount, radius))
            {
                viewBallsList.Add(new ViewBall(logicBall));
            }
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

