using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatePi.Models
{
    //This class estimates pi
    public class FindPi
    {
        public int n { get; set; }

        public FindPi() { } //Default Constructor

        public FindPi(int N) //Constructor
        {
            n = N;
        }

        public double EstimatePi(int n)
        {
            //Create a random real number between 0 and 1 n amount of times. Calculate pi.

            var rand = new Random(); //create outside loop so it creates a different rand every time
            double numCicrcle = 0;
            double numTotal = 0;
            for (int i = 0; i < n; i++)
            {
                //for each n create an (x,y) point 
                double x = rand.NextDouble(); //NextDouble() creates a double between 0 and 1, otherwise I would have to create an extension class
                double y = rand.NextDouble();

                double distance = (x * x) + (y * y); //no need to sqrt, 1 is the highest number that sqrt<=1 for so if x^2 + y^2 > 1 so will the sqrt
                if (distance <= 1)
                {
                    numCicrcle++;
                }
                numTotal++;
            }
            return 4 * (numCicrcle / numTotal);
        }
    }
}
