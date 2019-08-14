using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.Medium.War
{
    public class Card : IComparable<Card>
    {
        public string Value { get; set; }
        public string Type { get; set; }
        public int NumericalValue { get; set; }

        public Card(string valueaandtype)
        {
            Value = valueaandtype.Length == 2 ? valueaandtype[0].ToString() : valueaandtype.Substring(0, 2);
            Type = valueaandtype.Length == 2 ? valueaandtype[1].ToString() : valueaandtype[2].ToString();

            var possibleValue = 0;
            NumericalValue = int.TryParse(Value, out possibleValue) ? possibleValue : (Value == "J" ? 11 : (Value == "Q" ? 12 : (Value == "K" ? 13 : 14)));
        }

        public int CompareTo(Card other)
        {
            return this.NumericalValue < other.NumericalValue ? -1 : this.NumericalValue > other.NumericalValue ? 1 : 0;
        }

        public static bool operator <(Card c1, Card c2)
        {
            return c1.CompareTo(c2) == -1;
        }

        public static bool operator >(Card c1, Card c2)
        {
            return c1.CompareTo(c2) == 1;
        }

        public static bool operator ==(Card c1, Card c2)
        {
            return c1.CompareTo(c2) == 0;
        }

        public static bool operator !=(Card c1, Card c2)
        {
            return c1.CompareTo(c2) != 0;
        }

        public override string ToString()
        {
            return Value + Type + " (" + NumericalValue + ")";
        }
    }

    public class Solution
    {
        private static void Main(string[] args)
        {
            var cardsP1 = new Queue<Card>();
            var cardsP2 = new Queue<Card>();

            var n = int.Parse(Console.ReadLine()); // the number of cards for player 1
            for (var i = 0; i < n; i++)
            {
                var cardp1 = Console.ReadLine(); // the n cards of player 1
                cardsP1.Enqueue(new Card(cardp1));
            }
            var m = int.Parse(Console.ReadLine()); // the number of cards for player 2
            for (var i = 0; i < m; i++)
            {
                var cardp2 = Console.ReadLine(); // the m cards of player 2
                cardsP2.Enqueue(new Card(cardp2));
            }
            //TestWinner();

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            var rounds = 0;
            var winner = GetWinner(cardsP1, cardsP2, new Queue<Card>(), new Queue<Card>(), ref rounds);
            var outString = (winner == 0 ? "PAT" : winner == 1 ? "1" + " " + rounds : "2" + " " + rounds);
            Console.WriteLine(outString);
        }

        private static void TestWinner()
        {
        }

        public static int GetWinner(Queue<Card> q1, Queue<Card> q2, Queue<Card> onTableP1, Queue<Card> onTableP2, ref int rounds)
        {
            if (q1.Count == 0)
                return 2;

            if (q2.Count == 0)
                return 1;

            var card1 = q1.Dequeue();
            var card2 = q2.Dequeue();
            onTableP1.Enqueue(card1);
            onTableP2.Enqueue(card2);

            if (card1 > card2)
            {
                foreach (var card in onTableP1)
                {
                    q1.Enqueue(card);
                }
                foreach (var card in onTableP2)
                {
                    q1.Enqueue(card);
                }
                onTableP1.Clear();
                onTableP2.Clear();
                rounds++;
                return GetWinner(q1, q2, onTableP1, onTableP2, ref rounds);
            }

            if (card2 > card1)
            {
                foreach (var card in onTableP1)
                {
                    q2.Enqueue(card);
                }
                foreach (var card in onTableP2)
                {
                    q2.Enqueue(card);
                }
                onTableP1.Clear();
                onTableP2.Clear();
                rounds++;
                return GetWinner(q1, q2, onTableP1, onTableP2, ref rounds);
            }

            if (card1 == card2)
            {
                if (q1.Count < 4 || q2.Count < 4)
                {
                    rounds++;
                    return 0;//PAT
                }

                onTableP1.Enqueue(q1.Dequeue());
                onTableP1.Enqueue(q1.Dequeue());
                onTableP1.Enqueue(q1.Dequeue());

                onTableP2.Enqueue(q2.Dequeue());
                onTableP2.Enqueue(q2.Dequeue());
                onTableP2.Enqueue(q2.Dequeue());

                return GetWinner(q1, q2, onTableP1, onTableP2, ref rounds);
            }

            return 0;
        }
    }
}
