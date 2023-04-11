using Logika;

namespace AppTests
{
    [TestClass]
    public class LogicModelTests
    {
        [TestMethod]
        public void TestCreateBalls()
        {
            int expectedAmount = 5;
            var logicApi = LogicAbstractAPI.CreateApi();
            logicApi.CreateBalls(expectedAmount);
            Assert.AreEqual(expectedAmount, logicApi.Balls.Count);
            logicApi.Dispose();
        }
    }
}
