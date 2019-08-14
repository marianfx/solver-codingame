using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.Easy.Temperatures
{
    public class Solution
    {
        public static void Main()
        {
            Console.ReadLine();
            int temperature;
            try
            {
                temperature = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).OrderBy(x => x, Comparer<int>.Create((x, y) => x == y ? 0 : (Math.Abs(x) < Math.Abs(y) ? -1 : (Math.Abs(x) > Math.Abs(y) ? 1 : (x >= 0 ? -1 : 1))))).First();
            }
            catch
            {
                temperature = 0;
            }
            Console.Write(temperature);
        }
    }
}
