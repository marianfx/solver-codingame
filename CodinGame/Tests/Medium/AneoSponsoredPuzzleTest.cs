using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Solutions.Medium.AneoSponsoredPuzzle;
using FluentAssertions;

namespace Tests.Medium
{
    [TestClass]
    public class AneoSponsoredPuzzleTest
    {
        #region Setup
        private Solution solution;
        private StringWriter consoleOutputMock;
        private StringReader consoleInputMock;
        string outputString = @"60
";
        string inputString = @"200
6
1000 15
3000 10
4000 30
5000 30
6000 5
7000 10";

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
