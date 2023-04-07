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
            var logicModel = new LogicModel();
            logicApi.CreateBalls(expectedAmount);
            //Assert.AreEqual(expectedAmount, logicModel.Balls.Count);
            logicApi.Dispose();
        }
    }
}
