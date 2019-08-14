using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.Medium.ThereIsNoSpoon
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
            int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
            int[,] matrix = new int[height, width];

            // 1 = node cell
            // 0 = empty cell
            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine(); // width characters, each either 0 or .
                for (int j = 0; j < width; j++)
                    matrix[i, j] = line[j] == '0' ? 1 : 0;
            }

            // go check the neighbours
            // go through the matrix, and if we hit a valid node, compute it's neighbours
            String output;
            int xTemp, yTemp;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (matrix[i, j] != 1)
                        continue;

                    //write the node coordinates
                    output = String.Format("{0} {1} ", j, i);

                    //find first on right
                    //the idea is to go right with an temporary index until we hit the end or hit an '1' (node) in the matrix
                    //then update the coordinates to display;
                    for (xTemp = j + 1; xTemp < width && matrix[i, xTemp] != 1; xTemp++) ;
                    xTemp = xTemp < width ? xTemp : -1;
                    yTemp = xTemp < width ? i : -1;
                    output += String.Format("{0} {1} ", xTemp, yTemp);


                    //find first to the bottom
                    //same principle as above, only going down
                    for (yTemp = i + 1; yTemp < height && matrix[yTemp, j] != 1; yTemp++) ;
                    xTemp = yTemp < height ? j : -1;
                    yTemp = yTemp < height ? yTemp : -1;
                    output += String.Format("{0} {1} ", xTemp, yTemp);
                    Console.WriteLine(output);

                }
            }

            Console.ReadKey();

        }
    }
}
