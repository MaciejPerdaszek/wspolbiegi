using Logika;

namespace AppTests
{
    [TestClass]
    public class BorderTest
    {
        [TestMethod]
        public void GetterTest()
        {
            Border border = new Border(300, 400);
            Assert.AreEqual(border.Width, 300);
            Assert.AreEqual(border.Height, 400);
        }
    }
}
