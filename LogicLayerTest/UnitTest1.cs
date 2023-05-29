using Logika;
using Moq;
using NUnit.Framework;

namespace Logika.Tests
{
    [TestFixture]
    internal class LogicAbstractAPITests
    {
        [Test]
        public void CreateLogicBall()
        {
            double diameter = 10.0;
            double mass = 5.0;

            var logicBallMock = new Mock<TestLogicBall>();

            logicBallMock.Object.Diameter = diameter;
            logicBallMock.Object.Mass = mass;

            var logicAbstractApiMock = new Mock<LogicAbstractAPI>();
            logicAbstractApiMock.Setup(api => api.CreateBall(diameter, mass)).Returns(logicBallMock.Object);

            var obj = logicAbstractApiMock.Object;
            var result = obj.CreateBall(diameter, mass);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Diameter, Is.EqualTo(diameter));
            Assert.That(result.Mass, Is.EqualTo(mass));
        }

        [Test]
        public void CreateTable()
        {
            int width = 100;
            int height = 200;

            var logicAbstractApiMock = new Mock<LogicAbstractAPI>();

            logicAbstractApiMock.Setup(api => api.CreateTable(width, height)).Verifiable();

            var obj = logicAbstractApiMock.Object;
            obj.CreateTable(width, height);

            logicAbstractApiMock.Verify(api => api.CreateTable(width, height), Times.Once);
        }

        [Test]
        public void CreateBallWithNoInitiazeTable()
        {
            double diameter = 10.0;
            double mass = 5.0;

            var logicModel = new LogicModel();

            Assert.Throws<Exception>(() => logicModel.CreateBall(diameter, mass));
        }
    }
}
public class TestLogicBall : ILogicBall, IDisposable
{
    public double X { get; set; }
    public double Y { get; set; }
    public double speedX { get; set; }
    public double speedY { get; set; }
    public int directionX { get; set; }
    public int directionY { get; set; }
    public double Mass { get; set; }
    public double Diameter { get; set; }

    public event LogicBallChangedEventHandler LogicBallChanged;

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}