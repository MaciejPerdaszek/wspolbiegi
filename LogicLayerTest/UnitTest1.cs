using Dane;
using Logika;
using Moq;
using NUnit.Framework;

namespace Logika.Tests
{
    [TestFixture]
    public class LogicAbstractAPITests
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