using Dane;

namespace AppTests
{
    [TestClass]
    public class SphereTest
    {
       
        [TestMethod]
        public void GetterSetterTest()
        {
            Ball ball = new Ball(3.5, 5.5);
            Assert.AreEqual(ball.X, 3.5);
            Assert.AreEqual(ball.Y, 5.5);

            ball.X = 3.6;
            ball.Y = 5.6;

            Assert.AreEqual(ball.X, 3.6);
            Assert.AreEqual(ball.Y, 5.6);
        }

    }


}
