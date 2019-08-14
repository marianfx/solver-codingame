using System;

namespace Solutions.Easy.HorseRacingDuals
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());// read the number of horses
            int[] array = new int[N];
            int index = 0;

            //read & store the data in an array (for easy element access)
            for (int i = 0; i < N; i++)
            {
                int pi = int.Parse(Console.ReadLine());
                array[index++] = pi;
            }

            //sort the array
            Array.Sort(array);

            // find the min difference (it will sure be between two consecutive elements)
            int minDiff = 10000001;
            int diff = 0;
            for (int i = 0; i < N - 1; i++)
            {
                diff = Math.Abs(array[i] - array[i + 1]);
                if (diff < minDiff)
                    minDiff = diff;

                if (minDiff == 0) //reached the lowest diff, we can stop
                    break;
            }

            Console.WriteLine(minDiff);

        }
    }
}
