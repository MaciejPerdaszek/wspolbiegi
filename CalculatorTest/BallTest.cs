using Dane;

namespace AppTests
{
    [TestClass]
    public class BallTest
    {
       
        [TestMethod]
        public void ChangePositionTest()
        {
            Ball ball = new Ball(3, 5);

            Thread.Sleep(100);

            double x1 = ball.X;
            double y1 = ball.Y;
            Assert.AreNotEqual(x1, 3);
            Assert.AreNotEqual(y1, 5);

            Thread.Sleep(100);

            double x2 = ball.X;
            double y2 = ball.Y;
            Assert.AreNotEqual(x2, x1);
            Assert.AreNotEqual(y2, y1);
        }

    }


}
