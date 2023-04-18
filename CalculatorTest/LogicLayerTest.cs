using Logika;

namespace AppTests
{
    [TestClass]
    public class LogicModelTests
    {
        [TestMethod]
        public void TestCreateBalls()
        {
            var api = LogicAbstractAPI.CreateApi();
            int expectedAmount = 5;
            int radius = 10;

            List<ILogicBall> balls = api.CreateBalls(expectedAmount, radius);
            Assert.AreNotEqual(expectedAmount, balls.Count);

            int expectedWidth = 800;
            int expectedHeight = 600;
            api.CreateTable(expectedWidth, expectedHeight);

            balls = api.CreateBalls(expectedAmount, radius);
            Assert.AreEqual(expectedAmount, balls.Count);
        }

        [TestMethod]
        public void TestCreateBallsWithCorrectValues()
        {
            var api = LogicAbstractAPI.CreateApi();
            int expectedAmount = 5;
            int radius = 10;
            int expectedWidth = 600;
            int expectedHeight = 400;

            api.CreateTable(expectedWidth, expectedHeight);
            List<ILogicBall> balls = api.CreateBalls(expectedAmount, radius);
            Assert.AreEqual(expectedAmount, balls.Count);

            foreach (var ball in balls)
            {
                Assert.IsNotNull(ball);
                Assert.AreEqual(ball.Diameter, radius);
                Assert.IsTrue(ball.X >= 0 && ball.X <= 600);
                Assert.IsTrue(ball.Y >= 0 && ball.Y <= 400);
            }
        }
    }
}
