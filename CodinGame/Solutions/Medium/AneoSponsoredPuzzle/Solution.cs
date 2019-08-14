using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.Medium.AneoSponsoredPuzzle
{
    class Light
    {
        public int Distance { get; set; }
        public int Duration { get; set; }
        public int MaxSpeed { get; set; }

        public Light(int distance, int duration)
        {
            Distance = distance;
            Duration = duration;
        }

        public override string ToString()
        {
            return Distance.ToString() + "m -> " + Duration.ToString() + "s";
        }
    }

    public class Solution
    {
        public static void Main(string[] args)
        {
            int speed = int.Parse(Console.ReadLine());
            int lightCount = int.Parse(Console.ReadLine());
            Console.Error.WriteLine(speed);
            Console.Error.WriteLine(lightCount);

            var lights = new Light[lightCount];
            for (int i = 0; i < lightCount; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int distance = int.Parse(inputs[0]);
                int duration = int.Parse(inputs[1]);
                lights[i] = new Light(distance, duration);
                Console.Error.WriteLine(lights[i].ToString());
            }

            var maxSpeedMps = speed / (60.0 * 60.0) * 1000.0;

            // loop through lights and compute max speed, iterative
            int step = 0;
            while (step < lightCount)
            {
                // each light has a valid interval, which is the on
                // (x - 1) * A <= y <= x * A 
                // => x >= y/A && x <= y/A + 1
                // => x = ceil(y/A);
                // start = green => if x is odd, i can go

                // how many seconds until the current light
                var wasReset = false;
                while (true)
                {
                    var arriveIn = lights[step].Distance / maxSpeedMps;
                    var X = Math.Ceiling(arriveIn / lights[step].Duration * 1.0);
                    var isGood = (X % 2 == 1 && arriveIn != lights[step].Duration * X) 
                        || (X % 2 == 0 && arriveIn == lights[step].Duration * X);
                    if (isGood)
                        break;

                    wasReset = true;
                    speed--; // decrease KM, not M
                    maxSpeedMps = speed / (60.0 * 60.0) * 1000.0;

                    if (speed == 0)
                        break;
                }

                // recheck all
                step = wasReset ? 0 : step + 1;
            }

            Console.WriteLine(speed);
        }
    }
}
