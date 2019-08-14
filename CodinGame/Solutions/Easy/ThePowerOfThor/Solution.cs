using System;

namespace Solutions.Easy.ThePowerOfThor
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int LX = int.Parse(inputs[0]); // the X position of the light of power
            int LY = int.Parse(inputs[1]); // the Y position of the light of power
            int TX = int.Parse(inputs[2]); // Thor's starting X position
            int TY = int.Parse(inputs[3]); // Thor's starting Y position

            // game loop
            while (true)
            {
                int E = int.Parse(Console.ReadLine()); // The level of Thor's remaining energy, representing the number of moves he can still make.

                if (E <= 0)
                    return;

                if (LX > TX)
                {
                    if (LY > TY)
                    {
                        Console.WriteLine("SE");
                        TX++;
                        TY++;
                    }
                    else if (LY < TY)
                    {
                        Console.WriteLine("NE");
                        TX++;
                        TY--;
                    }
                    else
                    {
                        Console.WriteLine("E");
                        TX++;
                    }
                }
                else if (LX < TX)
                {
                    if (LY < TY)
                    {
                        Console.WriteLine("SW");
                        TX--;
                        TY--;
                    }
                    else if (LY > TY)
                    {
                        Console.WriteLine("SW");
                        TX--;
                        TY++;
                    }
                    else
                    {
                        Console.WriteLine("W");
                        TX--;
                    }
                }
                else if (LX == TX)
                {
                    if (LY == TY)
                        return;

                    if (LY < TY)
                    {
                        Console.WriteLine("N");
                        TY--;
                    }
                    else
                    {
                        Console.WriteLine("S");
                        TY++;
                    }
                }
            }
        }
    }
}
