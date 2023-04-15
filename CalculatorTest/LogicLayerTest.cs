/*using Logika;

namespace AppTests
{
    [TestClass]
    public class LogicModelTests
    {
        [TestMethod]
        public void TestCreateBalls()
        {
            var logicApi = LogicAbstractAPI.CreateApi();
            logicApi.CreateTable(600, 400);
            int expectedAmount = 5;

            logicApi.CreateBalls(expectedAmount);

            var balls = logicApi.GetBallsList();
            Assert.AreEqual(expectedAmount, balls.Count);

            foreach (var ball in balls)
            {
                Assert.IsNotNull(ball);
                Assert.IsTrue(ball.X >= 0 && ball.X <= 600);
                Assert.IsTrue(ball.Y >= 0 && ball.Y <= 400);
            }

            logicApi.Dispose();
        }
    }
}*/
