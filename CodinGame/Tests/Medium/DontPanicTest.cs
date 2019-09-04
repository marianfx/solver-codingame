using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Solutions.Medium.DontPanic;
using FluentAssertions;

namespace Tests.Medium
{
    [TestClass]
    public class DontPanicTest
    {
        #region Setup
        private Solution solution;
        private StringWriter consoleOutputMock;
        private StringReader consoleInputMock;
        string outputString = @"E
E
E
";
        string inputString = @"1 13 100 0 2 10 0 0
0 10 RIGHT
0 10 RIGHT
";

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
