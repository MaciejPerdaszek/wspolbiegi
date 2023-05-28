using System.Collections.Generic;
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

        public override List<IViewBall> CreateBalls(int amount, double diameter, double mass)
        {
            List<IViewBall> list = new List<IViewBall>();
            for (int i = 0; i < amount; i++)
                list.Add(new ViewBall(LogicApi.CreateBall(diameter, mass)));
            
            return list;
        }

        public override void Dispose()
        {
            LogicApi.Dispose();
        }

        public override void CreateTable(int width, int height)
        {
            LogicApi.CreateTable(width, height);
        }

        public override void SaveRecord()
        {
            LogicApi.SaveRecord();
        }
    }
}

