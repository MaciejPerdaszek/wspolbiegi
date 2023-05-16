using Dane;
using Moq;
using NUnit.Framework;

namespace Dane.Tests
{
    [TestFixture]
    public class DataAbstractAPITests
    {
        [Test]
        public void CreateDataBall()
        {
            double x = 1.0;
            double y = 2.0;
            var ballMock = new Mock<TestDataBall>();

            ballMock.Object.X = x;
            ballMock.Object.Y = y;

            var dataAbstractApiMock = new Mock<DataAbstractAPI>();
            dataAbstractApiMock.Setup(api => api.CreateBall(x, y)).Returns(ballMock.Object);
            var obj = dataAbstractApiMock.Object;
            var result = obj.CreateBall(x, y);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.X, Is.EqualTo(x));
            Assert.That(result.Y, Is.EqualTo(y));
        }
    }
}
public class TestDataBall : ILogicBall, IDisposable
{
    public double X { get; set; }
    public double Y { get; set; }
    public double speedX { get; set; }
    public double speedY { get ; set; }
    public int directionX { get ; set; }
    public int directionY { get ; set; }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}