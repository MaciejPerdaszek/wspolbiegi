using Moq;
using NUnit.Framework;
using Dane;

namespace Dane.Tests
{
    [TestFixture]
    internal class DataAbstractAPITests
    {
        [Test]
        public void CreateDataBall()
        {
            double x = 1.0;
            double y = 2.0;
            var ballMock = new Mock<IDataBall>();

            ballMock.SetupProperty(b => b.speedX, 0.0);
            ballMock.SetupProperty(b => b.speedY, 0.0);
            ballMock.SetupProperty(b => b.directionX, 0);
            ballMock.SetupProperty(b => b.directionY, 0);

            ballMock.Object.speedX = x;
            ballMock.Object.speedY = y;

            var dataAbstractApiMock = new Mock<DataAbstractAPI>();
            dataAbstractApiMock.Setup(api => api.CreateBall(x, y)).Returns(ballMock.Object);
            var obj = dataAbstractApiMock.Object;
            var result = obj.CreateBall(x, y);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.speedX, Is.EqualTo(x));
            Assert.That(result.speedY, Is.EqualTo(y));
        }
    }
}