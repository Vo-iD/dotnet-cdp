using NUnit.Framework;

namespace StringCalculatorKata
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Should_Return_Zero_If_Was_Empty_String()
        {
            Assert.AreEqual(0, _calculator.Add(string.Empty));
        }

        [Test]
        public void Should_Return_Number_If_Was_Single_Number()
        {
            Assert.AreEqual(5, _calculator.Add("5"));
        }

        [Test]
        public void Should_Return_Sum_Of_Two_Numbers()
        {
            Assert.AreEqual(6, _calculator.Add("5,1"));
        }

        [TestCase("1,2,3,4", 10)]
        [TestCase("0,0,0,0,0", 0)]
        [TestCase("0,0,0,5,0", 5)]
        [TestCase("0,0,0,5,0,1,1,1,1,1", 10)]
        public void Should_Return_Sum_Of_Unkown_Amount_Of_Numbers(string input, int expected)
        {
            Assert.AreEqual(expected, _calculator.Add(input));
        }
    }
}
