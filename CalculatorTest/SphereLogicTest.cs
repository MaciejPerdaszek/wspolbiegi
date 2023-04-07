using Logika;

namespace AppTests
{
    [TestClass]
    public class SphereLogicTest
    {
        [TestMethod]
        public void GetterTest()
        {
           LogicModel sphere = new LogicModel();
           sphere.createSpheres(4, 5);
           Assert.AreEqual(sphere.SphereList.Count, 4);
            for (int i = 0; i < sphere.SphereList.Count; i++)
            {
                Assert.AreEqual(i * 5, sphere.SphereList[i].X);
                Assert.AreEqual(i * 5, sphere.SphereList[i].Y);
                Assert.AreEqual(5, sphere.SphereList[i].Radius);

            }
        }
    }
}