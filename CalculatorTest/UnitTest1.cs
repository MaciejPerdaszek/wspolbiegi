using ClassLibrary1;

namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(calculator.add(2, 3), 5);
        }
    }
}