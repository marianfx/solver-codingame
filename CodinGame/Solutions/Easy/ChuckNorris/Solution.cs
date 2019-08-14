using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.Easy.ChuckNorris
{
    public class Solution
    {
        static void Main(string[] args)
        {
            string MESSAGE = Console.ReadLine();
            int[] bytes = new int[100 * 7];//7 bits per element, 100 max N
            int length = 0;
            int i = 0;

            //save bytes in an array
            for (; i < MESSAGE.Length; i++)
            {
                //remember, only the first 7 matter (ASCII)
                int c = MESSAGE[i];
                for (int j = 6; j >= 0; j--)
                {
                    //use bitwise operands (faster)
                    bytes[length + j] = c & 1;
                    c = c >> 1;
                }
                length += 7;
            }

            //transpose
            i = 0;
            String output = "";
            int noOfRepeats;
            while (i < length)
            {
                output = bytes[i] == 1 ? "0" : "00";
                noOfRepeats = 1;

                // loop to find no. of repeats
                int j = i + 1;
                for (; j < length && bytes[i] == bytes[j]; j++, noOfRepeats++) ;

                i = j;
                output += " 0".PadRight(noOfRepeats == 1 ? noOfRepeats : noOfRepeats + 1, '0');             // use Pad Function to add the required number of zeroes
                Console.Write(i == length ? output : output + " ");
            }

        }
    }
}
