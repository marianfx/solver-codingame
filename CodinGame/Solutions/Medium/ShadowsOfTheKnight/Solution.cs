using System;

namespace Solutions.Medium.ShadowsOfTheKnight
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int W = int.Parse(inputs[0]); // width of the building.
            int H = int.Parse(inputs[1]); // height of the building.
            int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
            inputs = Console.ReadLine().Split(' ');
            int X0 = int.Parse(inputs[0]);
            int Y0 = int.Parse(inputs[1]);

            Console.Error.WriteLine($"N = {N}; Board: {W}x{H}");

            // game loop
            int xStart = 0; int yStart = 0; int xEnd = W - 1; int yEnd = H - 1;
            while (true)
            {
                string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
                if (string.IsNullOrEmpty(bombDir) || N == 0)
                    return;

                // the location of the next window Batman should jump to.
                Console.Error.WriteLine($"FROM: [{xStart}, {yStart}] [{xEnd}, {yEnd}]. B: ({X0}, {Y0})");
                DecideStrategy(bombDir,
                    ref X0, ref Y0,
                    ref xStart, ref xEnd, ref yStart, ref yEnd);

                Console.Error.WriteLine($"TO: [{xStart}, {yStart}] [{xEnd}, {yEnd}]. B: ({X0}, {Y0})");
                N--;
                Console.WriteLine($"{X0} {Y0}");
            }

        }

        public static void DecideStrategy(string dir,
             ref int xBatman, ref int yBatman,
             ref int xStart, ref int xEnd, ref int yStart, ref int yEnd)
        {
            // first the easy ones
            if (dir == "U")
            {
                yEnd = yBatman - 1;
                yBatman = (yStart + yEnd) / 2;
            }

            if (dir == "D")
            {
                yStart = yBatman + 1;
                yBatman = (yStart + yEnd) / 2;
            }

            if (dir == "R")
            {
                xStart = xBatman + 1;
                xBatman = (xStart + xEnd) / 2;
            }

            if (dir == "L")
            {
                xEnd = xBatman - 1;
                xBatman = (xStart + xEnd) / 2;
            }

            if (dir == "UR")
            {
                yEnd = yBatman - 1;
                xStart = xBatman + 1;
                xBatman = (xStart + xEnd) / 2;
                yBatman = (yStart + yEnd) / 2;
            }

            if (dir == "DR")
            {
                yStart = yBatman + 1;
                xStart = xBatman + 1;
                xBatman = (xStart + xEnd) / 2;
                yBatman = (yStart + yEnd) / 2;
            }

            if (dir == "DL")
            {
                yStart = yBatman + 1;
                xEnd = xBatman - 1;
                xBatman = (xStart + xEnd) / 2;
                yBatman = (yStart + yEnd) / 2;
            }

            if (dir == "UL")
            {
                yEnd = yBatman - 1;
                xEnd = xBatman - 1;
                xBatman = (xStart + xEnd) / 2;
                yBatman = (yStart + yEnd) / 2;
            }
        }
    }
}
