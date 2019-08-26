using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Solutions.Medium.SkynetRevolution;
using System.IO;
using FluentAssertions;

namespace Tests.Medium
{
    [TestClass] public class SkynetRevolutionTest
    {
        #region Setup
        private Solution solution;
        private StringWriter consoleOutputMock;
        private StringReader consoleInputMock;
        string outputString = @"1 3
2 3
";
        string inputString = @"4 4 1
0 1
0 2
1 3
2 3
3
0
2";

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
