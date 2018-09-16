using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. It the coordinates only represent 1/4th of the circle.
//2. The larger numbers of iterations are more accurate.
//3. It generates the random string based on the time when it starts.  Then using nextdouble it continues to use the next number
//      in the string from then on so it doesn't reuse the same part of the string or same string between attempts.
//4. I ran 100 Million iterations and it took 3-4 seconds and was within just over 2 millionths of math.pi.

namespace MonteCarlo
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter;
            long numOps;
            int inRadius;
            double ratioInOut;
            double distance;
            double[,] coordinates;
            XYCoords xySet;
            XYCoords xyStore;
            Random randomGen = new Random();
            do
            {
                counter = 0;
                inRadius = 0;
                Console.WriteLine("Enter number of Iterations:");
                if (long.TryParse(Console.ReadLine(), out numOps))
                {
                    coordinates = new double[numOps, 2];
                    do
                    {
                        xySet = new XYCoords(randomGen);
                        coordinates[counter, 0] = xySet.x;
                        coordinates[counter, 1] = xySet.y;
                        counter++;
                    }
                    while (counter < numOps);
                    counter = 0;
                    do
                    {
                        xyStore = new XYCoords(coordinates[counter, 0], coordinates[counter, 1]);
                        distance = Distance(xyStore);
                        if (distance <= 1.0)
                        {
                            ++inRadius;
                        }
                        counter++;
                    }
                    while (counter < numOps);
                    ratioInOut = ((inRadius / 1.0) / (numOps / 1.0)) * 4.0;
                    Console.WriteLine($"Number of points inside radius: {inRadius}");
                    Console.WriteLine($"Absolute difference between estimate of pi and math.pi: {Math.Abs(ratioInOut - Math.PI)}");
                }
            }
            while (true);
        }

        static double Distance(XYCoords xAndY) => Math.Sqrt((xAndY.x * xAndY.x) + (xAndY.y * xAndY.y));
    }

    struct XYCoords
    {
        public double x;
        public double y;

        public XYCoords(Random rando)
        {
            x = rando.NextDouble();
            y = rando.NextDouble();
        }

        public XYCoords(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
