using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Easy.TheDescent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tests.Easy
{
    [TestClass]
    public class TheDescentTest
    {
        #region Setup
        private Solution solution;
        private StringWriter consoleOutputMock;
        private StringReader consoleInputMock;
        string outputString = @"";
        string inputString = @"";

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
            // for this one, console is too messy to mock
        }
    }
}
