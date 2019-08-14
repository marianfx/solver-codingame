using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Solutions.Medium.War;
using System.IO;
using FluentAssertions;

namespace Tests.Medium
{
    [TestClass]
    public class WarTest
    {
        #region Setup
        private Solution solution;
        private StringWriter consoleOutputMock;
        private StringReader consoleInputMock;
        string outputString = @"E
E
E
";
        string inputString = @"10 10 7 10
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
        public void Given_Solution_When_TestingWithSimpleCards_Then_ShouldBeNoWinner()
        {
            var cardsP1 = new Queue<Card>();
            var cardsP2 = new Queue<Card>();

            var cards1 = new string[] { "10D", "9S", "8D", "KH", "7D", "5H", "6S" };
            var cards2 = new string[] { "10H", "7H", "5C", "QC", "2C", "4H", "6D" };

            for (int i = 0; i < cards1.Length; i++)
            {
                cardsP1.Enqueue(new Card(cards1[i]));
                cardsP2.Enqueue(new Card(cards2[i]));
            }

            int rounds = 0;
            var winner = Solution.GetWinner(cardsP1, cardsP2, new Queue<Card>(), new Queue<Card>(), ref rounds);
            winner.Should().Be(0);
        }
    }
}
