using Dane;

namespace AppTests
{
    [TestClass]
    public class SphereTest
    {
        Ball sphere = new Ball(4.3, 3.5, 5.5);
        [TestMethod]
        public void GetterSetterTest()
        {
            Assert.AreEqual(sphere.Radius, 4.3);
            Assert.AreEqual(sphere.X, 3.5);
            Assert.AreEqual(sphere.Y, 5.5);

            sphere.Radius = 5.0;
            sphere.X = 3.6;
            sphere.Y = 5.6;

            Assert.AreEqual(sphere.Radius, 5.0);
            Assert.AreEqual(sphere.X, 3.6);
            Assert.AreEqual(sphere.Y, 5.6);
        }

        [TestMethod]    
        public void UpdatePositionTest() {
            sphere.UpdatePosition();
            double positionX = sphere.X;
            double positionY = sphere.Y;    
            sphere.UpdatePosition();
            double positionX1 = sphere.X;
            double positionY1 = sphere.Y;
            Assert.AreNotSame(positionX1, positionX);
            Assert.AreNotSame(positionY1, positionY); 
        }

    }


}
