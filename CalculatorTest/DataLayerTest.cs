/*using Dane;

namespace AppTests
{
    [TestClass]
    public class DataModelTests
    {
        [TestMethod]
        public void TestCreateBall()
        {
            var api = DataAbstractAPI.CreateApi();
            double x = 1.3, y = 1.5;

            api.CreateBall(x, y);
            IBall ball = api.CreateBall(x, y);
            Assert.AreEqual(x, ball.X);
            Assert.AreEqual(y, ball.Y);

            api.Dispose();
        }

        [TestMethod]
        public void TestGetBallList()
        {
            var api = DataAbstractAPI.CreateApi();
            int amount = 2;

            for (int i = 0; i < amount; i++)
            {
                IBall ball = api.CreateBall(i, i);
            }
            List<IBall> balls = api.GetBallsList();
            Assert.AreEqual(amount, balls.Count);

            api.Dispose();
        }
    }
}
*/