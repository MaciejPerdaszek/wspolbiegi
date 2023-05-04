using Dane;
using Logika;
using Moq;
using System.ComponentModel;

[TestFixture]
public class LogicAbstractAPITests
{
    [Test]
    public void TestCreateBalls()
    {
        var api = new Mock<LogicAbstractAPI>() { CallBase = true }; ;
        api.Setup(x => x.CreateBalls(It.IsAny<int>(), It.IsAny<double>()))
               .Returns(new List<ILogicBall> { new Mock<ILogicBall>().Object, new Mock<ILogicBall>().Object });

        var result = api.Object.CreateBalls(2, 10);

        Assert.That(result.Count, Is.EqualTo(2));
    }
}
