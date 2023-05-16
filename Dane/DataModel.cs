namespace Dane
{
    internal class DataModel : DataAbstractAPI
    {
        public override ILogicBall CreateBall(double x, double y)
        {
            Ball newBall = new(x,y);
            return newBall;
        }
    }
}
