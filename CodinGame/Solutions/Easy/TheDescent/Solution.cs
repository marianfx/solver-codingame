using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.Easy.TheDescent
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            List<Int32> mountainsLoops = new List<Int32>();
            // game loop
            while (true)
            {
                mountainsLoops.Clear();
                for (int i = 0; i < 8; i++)
                {
                    int mountainH = int.Parse(Console.ReadLine()); // represents the height of one mountain.
                    mountainsLoops.Add(mountainH);
                }

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");
                int index = mountainsLoops.IndexOf(mountainsLoops.Max());

                Console.WriteLine(index); // The index of the mountain to fire on.
            }
        }
    }
}
