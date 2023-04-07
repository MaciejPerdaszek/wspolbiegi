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
            var observer = new BallObserver();

            api.Subscribe(observer);
            api.CreateBall(1.3, 1.5);
            api.CreateBall(2.3, 2.5);
            api.Dispose();

            // Check that the observer received the expected number of notifications
            Assert.AreEqual(2, observer.NumBallsCreated);

        }
    }

    class BallObserver : IObserver<IBall>
    {
        public int NumBallsCreated { get; private set; }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(IBall value)
        {
            NumBallsCreated++;
        }
    }
}
