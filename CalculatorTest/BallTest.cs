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

            Assert.AreNotEqual(ball.X, 3);
            Assert.AreNotEqual(ball.Y, 5);
        }

    }


}
