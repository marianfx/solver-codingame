using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Easy.ThePowerOfThor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tests.Easy
{
    [TestClass]
    public class ThePowerOfThorTest
    {
        #region Setup
        private Solution solution;
        private StringWriter consoleMock;

        [TestInitialize]
        public void SetUp()
        {
            solution = new Solution();
            consoleMock = new StringWriter();
            Console.SetOut(consoleMock);
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
            var outputString =
@"E
E
E
";
            var inputString =
@"10 10 7 10
10
9
8
7
6
5
4
3
2
1";

            // init
            var inputStream = new StringReader(inputString);
            Console.SetIn(inputStream);

            //given = in test initialize
            Solution.Main(new string[] {});
            var output = consoleMock.ToString();
            output.Should().Be(outputString);
        }
    }
}
