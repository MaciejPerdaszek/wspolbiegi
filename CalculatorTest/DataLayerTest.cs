using Dane;

namespace AppTests
{
    [TestClass]
    public class DataModelTests
    {
        [TestMethod]
        public void TestCreateBall()
        {
            var api = DataAbstractAPI.CreateApi();
            double expectedX = 10.0;
            double expectedY = 20.0;

            IBall ball = api.CreateBall(expectedX, expectedY);

            Assert.AreEqual(expectedX, ball.X);
            Assert.AreEqual(expectedY, ball.Y);
        }
    }
}
