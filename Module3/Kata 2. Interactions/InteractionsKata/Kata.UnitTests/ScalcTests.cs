using Moq;
using NUnit.Framework;
using scalc;
using StringCalculatorKata.Contracts;

namespace Kata.UnitTests
{
    [TestFixture]
    public class ScalcTests
    {
        private Mock<IConsoleProxy> _consoleMock;
        private Mock<ILogger> _loggerMock;
        private Mock<IWebService> _webServiceMock;

        [SetUp]
        public void SetUp()
        {
            _consoleMock = new Mock<IConsoleProxy>();
            _loggerMock = new Mock<ILogger>();
            _webServiceMock = new Mock<IWebService>();

            Program.Console = _consoleMock.Object;
            Program.Logger = _loggerMock.Object;
            Program.WebService = _webServiceMock.Object;
        }

        [TestCase("", 0)]
        [TestCase("20", 20)]
        [TestCase("3,5", 8)]
        [TestCase("3,5\n2", 10)]
        [TestCase("//*\n1*2*3", 6)]
        public void Should_Display_Result_If_Number_Passed(string input, int expected)
        {
            Program.Main(new[] { input });

            _consoleMock.Verify(c => c.WriteLine(string.Format("The result is {0}", expected)));
        }

        [Test]
        public void Should_Show_Another_Input_Asking()
        {
            Program.Main(new[] { string.Empty });

            _consoleMock.Verify(c => c.WriteLine("another input please"));
        }

        [Test]
        public void Should_Ask_Another_Input()
        {
            Program.Main(new[] { "1,2" });

            _consoleMock.Verify(c => c.Read(), Times.AtLeastOnce);
        }

        [Test]
        public void Should_Display_Result_Of_The_Second_Input()
        {
            _consoleMock.SetupSequence(c => c.Read())
                .Returns("1,3,6")
                .Returns(string.Empty);

            Program.Main(new[] { "1,2" });

            _consoleMock.Verify(c => c.WriteLine(string.Format("The result is {0}", 3)), Times.Once);
            _consoleMock.Verify(c => c.WriteLine(string.Format("The result is {0}", 10)), Times.Once);
        }

        [Test]
        public void Should_Ask_User_Input_Until_Empty_Line_Passed()
        {
            _consoleMock.SetupSequence(c => c.Read())
                .Returns("2")
                .Returns("2")
                .Returns("2")
                .Returns("2")
                .Returns("2")
                .Returns(string.Empty);

            Program.Main(new[] { "1,2" });

            _consoleMock.Verify(c => c.Read(), Times.Exactly(6));
        }

        [Test]
        public void Should_Display_Result_For_Each_User_Input()
        {
            _consoleMock.SetupSequence(c => c.Read())
                .Returns("2")
                .Returns("2")
                .Returns("2")
                .Returns("2")
                .Returns("2")
                .Returns(string.Empty);

            Program.Main(new[] { "1,1" });

            _consoleMock.Verify(c => c.WriteLine(string.Format("The result is {0}", 2)), Times.Exactly(6));
        }

        [Test]
        public void Should_Process_Another_Input_If_Args_Array_Is_Empty()
        {
            _consoleMock.SetupSequence(c => c.Read())
                .Returns("1,3,6")
                .Returns(string.Empty);

            Program.Main(new string[0]);

            _consoleMock.Verify(c => c.WriteLine(string.Format("The result is {0}", 10)), Times.Once);
        }
    }
}
