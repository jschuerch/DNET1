using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Raumschiff
{
    class Integrator
    {
        private static readonly int nOfIterations = 100;

        public double Integrate(Func<double, double> func, double min, double max, int iterations)
        {
            double d = Math.Abs((max - min) / iterations);
            double sum = func(min);

            for (int i = 1; i < iterations; i++)
            {
                sum += 2 * func(min + i*d);
            }
            
            sum += func(max);
            sum = d * sum /2;

            return sum;
        }

        public double AdaptiveIntegrate(Func<double, double> func, double min, double max)
        {
            int iterations = 2;
            int nOfIterations = 0;
            double difference = 10;
            double toleranz = 0.0001;
            double lastSum = Integrate(func, min, max, iterations);
            double currentSum = 0;

            while (difference > toleranz && nOfIterations++ <= 1000)
            {
                iterations *= 2;
                currentSum = Integrate(func, min, max, iterations);
                difference = Math.Abs(lastSum - currentSum);
                lastSum = currentSum;
            }

            return currentSum;
        }

        static void Main(string[] args)
        {
            Func<double, double> f = x => x;
            Console.WriteLine("Result: " + (new Integrator()).Integrate(f, 0, 10, nOfIterations));

            Func<double, double> f2 = x => Math.Pow(x, 2);
            Console.WriteLine("Result: " + (new Integrator()).AdaptiveIntegrate(f2, 0, 15));

            Console.ReadKey();
        }
    }

}
