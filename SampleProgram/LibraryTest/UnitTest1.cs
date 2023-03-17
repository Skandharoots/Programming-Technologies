using Library;
using System.Linq.Expressions;

namespace LibraryTest {
    [TestClass]
    public class CalculatorTest {

        Calculator calc;
        int a, b;

        [TestInitialize] public void TestInitialize() {
            calc = new Calculator();
            a = 2;
            b = 3;
        }

        [TestMethod] public void AddTest() {
            Assert.AreEqual(calc.Add(a,b), 5, "Lol not work");
        }

        [TestMethod] public void SubtractTest() {
            Assert.AreEqual(calc.Subtract(a, b), -1);
        }

        [TestMethod] public void MultiplyTest() {
            Assert.AreEqual(calc.Multiply(a, b), 6);
        }

        [TestMethod] public void DivideTest() {
            Assert.AreEqual(calc.Divide(a, b), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException), "Dividing a non-zero by zero doesn't raise exception.")]
        public void DivideNumberByZeroTest() {
            calc.Divide(a, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException), "Dividing zero by zero doesn't raise exception.")]
        public void DivideZeroByZeroTest() {
            calc.Divide(0, 0);
        }
    }
}