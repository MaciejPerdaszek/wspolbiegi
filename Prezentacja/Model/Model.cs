using System.Collections.Generic;
using Dane;
using Logika;

namespace Prezentacja.Model
{
    public class Model : ModelAbstractAPI
    {
        private readonly LogicAbstractAPI LogicApi;

        public List<ScreenBall> ScreenBalls = new();

        public Model()
        {
            LogicApi = LogicAbstractAPI.CreateApi();
        }

        public override void CreateBalls(int amount)
        {
            LogicApi.CreateBalls(amount);
            foreach(IBall ball in LogicApi.GetBallsList())
            {
                CreateScreenBall(ball, 5);
            }
        }

        public override List<ScreenBall> GetScreenBalls()
        {
            return ScreenBalls;
        }

        private void CreateScreenBall(IBall ball, double diameter)
        {
            ScreenBalls.Add(new ScreenBall(ball, 5));
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

