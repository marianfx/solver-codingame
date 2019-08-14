using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.Easy.AsciiArt
{
    public class Solution
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string text = Console.ReadLine().ToUpper();//ignore case @ManHaTaN
            int index;

            for (int i = 0; i < height; i++)
            {
                String ROW = Console.ReadLine();
                foreach (char letter in text)
                {
                    index = letter >= 'A' && letter <= 'Z' ? letter - 65 : 26;      //get the index (0-25 for letters, 26 for '?' or anything else)
                    String display = ROW.Substring(index * width, width);           //use the index to Substring the ASCII representatio of the letter from the row
                    Console.Write(display);
                }
                Console.WriteLine();
            }
        }
    }
}
