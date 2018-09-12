using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter;
            int numOps;
            int inRadius;
            Random randomGen = new Random();
            do
            {
                counter = 0;
                inRadius = 0;
                Console.WriteLine("Enter number of Iterations:");
                if (int.TryParse(Console.ReadLine(), out numOps))
                {
                    do
                    {

                        XYCoords xySet = new XYCoords(randomGen);
                        XYCoords xyStore = new XYCoords(xySet.x, xySet.y);


                        counter++;
                    }
                    while (counter < numOps);

                }
            }
            while (true);
        }

        public double distance(XYCoords xAndY) => Math.Sqrt((xAndY.x * xAndY.x) + (xAndY.y * xAndY.y));
        
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
