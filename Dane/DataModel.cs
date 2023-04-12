namespace Dane
{
    internal class DataModel : DataAbstractAPI
    {

        private List<IBall> ballsList = new();

        public override void Dispose()
        {
            foreach (Ball b in ballsList)
                b.Dispose();
        }

        public override IBall CreateBall(double x, double y)
        {
            Random r = new();
            Ball newBall = new(x, y);
            ballsList.Add(newBall);
            return newBall;
        }

        public override List<IBall> GetBallsList()
        {
            return ballsList;
        }
    }
}
