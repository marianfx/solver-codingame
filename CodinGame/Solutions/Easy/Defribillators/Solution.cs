using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.Easy.Defribillators
{
    class Defibrilator
    {
        public Defibrilator() { }

        public Defibrilator(String name, float x, float y)
        {
            Name = name;
            X = x;
            Y = y;
        }

        public String Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        /// <summary>
        /// Static converter from degrees to radians
        /// </summary>
        /// <param name="angle">The angle, expressed in degrees</param>
        /// <returns></returns>
        public static float ToRadians(float angle)
        {
            return ((float)Math.PI / 180.0f) * angle;
        }

        /// <summary>
        /// Returns the distance between two world coordinates (input is in degrees, so transformation in radians required)
        /// </summary>
        /// <returns></returns>
        public static float getDistance(float x1, float y1, float x2, float y2)
        {
            float X1 = Defibrilator.ToRadians(x1);
            float X2 = Defibrilator.ToRadians(x2);
            float Y1 = Defibrilator.ToRadians(y1);
            float Y2 = Defibrilator.ToRadians(y2);

            float XX = (X2 - X1) * (float)Math.Cos((Y1 + Y2) / 2.0f);
            float YY = Y2 - Y1;
            float distance = (float)Math.Sqrt(XX * XX + YY * YY) * 6371.0f;
            return distance;
        }
    }

    public class Solution
    {
        public static void Main(string[] args)
        {
            // carefull with float parsing, some computers interpret ',' as separation, others the '.' (local settings matter)
            float myX = float.Parse(Console.ReadLine().Replace(',', '.'));//the longitude
            float myY = float.Parse(Console.ReadLine().Replace(',', '.'));//the latitude
            int N = int.Parse(Console.ReadLine());//nr. of defibrilators

            // read the defribrilators data and store it in a list
            List<Defibrilator> defribilators = new List<Defibrilator>();
            for (int i = 0; i < N; i++)
            {
                string defString = Console.ReadLine();
                string[] defData = defString.Split(new char[] { ';' });

                String tempName = defData[1];
                float tempX = float.Parse(defData[4].Replace(',', '.'));
                float tempY = float.Parse(defData[5].Replace(',', '.'));
                Defibrilator d = new Defibrilator(tempName, tempX, tempY);
                defribilators.Add(d);
            }

            // get the result by sorting the list using as criteria the distance between the points and the user position
            //we use lambda expression, for demonstration purposes
            String result = defribilators.OrderBy(x => x,
                Comparer<Defibrilator>.Create(
                    (d1, d2) =>
                    {
                        float dist1 = Defibrilator.getDistance(d1.X, d1.Y, myX, myY);
                        float dist2 = Defibrilator.getDistance(d2.X, d2.Y, myX, myY);

                        return dist1 == dist2 ? 0 : (dist1 < dist2 ? -1 : 1);
                    }
                )).ToList()[0].Name;

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
