namespace Dane
{
    internal class DataModel : DataAbstractAPI
    {
        public override IBall CreateBall(double x, double y)
        {
            Random r = new();
            Ball newBall = new(x, y);
            Thread ballThread = new Thread(() => //?
            {
                while (true)
                {
                    lock(newBall)
                    {
                        //?
                    }
                }
            });
            ballThread.Start();
            return newBall;
        }
    }
}
