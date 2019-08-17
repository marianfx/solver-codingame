using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Solutions.Medium.ShadowsOfTheKnight;
using System.IO;
using FluentAssertions;

namespace Tests.Medium
{
    [TestClass]
    public class ShadowsOfTheKnightTest
    {
        #region Setup
        private Solution solution;
        private StringWriter consoleOutputMock;
        private StringReader consoleInputMock;
        string outputString = @"13 14
19 6
22 2
23 2
24 2
";
        string inputString = @"25 33
49
2 29
UR
UR
UR
R
R";

        [TestInitialize]
        public void SetUp()
        {
            solution = new Solution();
            consoleOutputMock = new StringWriter();
            consoleInputMock = new StringReader(inputString);
            Console.SetIn(consoleInputMock);
            Console.SetOut(consoleOutputMock);
        }

        [TestCleanup]
        public void TearDown()
        {
            solution = null;
        }
        #endregion

        [TestMethod]
        public void Given_Solution_When_TestingWithSampleInput_Then_Should_GetGoodResult()
        {
            //given = in test initialize
            Solution.Main(new string[] { });
            var output = consoleOutputMock.ToString();
            output.Should().Be(outputString);
        }
    }
}
