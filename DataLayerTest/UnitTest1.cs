/*using Dane;
using Moq;

[TestFixture]
public class DataAbstractAPITests
{
    [Test]
    public void CreateBall_ShouldReturnBallWithCorrectCoordinates()
    {
        double x = 1.0;
        double y = 2.0;
        var ballMock = new Mock<IBall>();

        ballMock.SetupProperty(b => b.X, x);
        ballMock.SetupProperty(b => b.Y, y);

        var dataAbstractApiMock = new Mock<DataAbstractAPI>();
        dataAbstractApiMock.Setup(api => api.CreateBall(x, y)).Returns(ballMock.Object); 
        var sut = dataAbstractApiMock.Object;
        var result = sut.CreateBall(x, y);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.X, Is.EqualTo(x));
        Assert.That(result.Y, Is.EqualTo(y));
    }
}
*/