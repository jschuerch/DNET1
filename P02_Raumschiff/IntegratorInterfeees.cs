using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_Raumschiff
{
    class IntegratorInterfeees
    {
        private static readonly int nOfIterations = 100;

        public double Integrate(IFunction func, double min, double max, int iterations)
        {
            double d = Math.Abs((max - min) / iterations);
            double sum = func.F(min);

            for (int i = 1; i < iterations; i++)
            {
                sum += 2 * func.F(min + i*d);
            }
            
            sum += func.F(max);
            sum = d * sum /2;

            return sum;
        }

        public double AdaptiveIntegrate(IFunction func, double min, double max)
        {
            int iterations = 2;
            int nOfIterations = 0;

            double toleranz = 0.0001;
            double difference = toleranz*1000;

            double lastSum = Integrate(func, min, max, iterations);
            double currentSum = 0;

            while (difference > toleranz && nOfIterations <= 1000)
            {
                nOfIterations++;
                iterations *= 2;

                currentSum = Integrate(func, min, max, iterations);
                difference = Math.Abs(lastSum - currentSum);

                lastSum = currentSum;
            }

            return currentSum;
        }

        static void MainIntegratorInterfeees(string[] args)
        {
            Console.WriteLine("Result: \n" + (new IntegratorInterfeees()).Integrate(new Function(), 0, 10, nOfIterations));
            
            Console.WriteLine("Adaptive Result: \n" + (new IntegratorInterfeees()).AdaptiveIntegrate(new QuadFunction(), 0, 15));
            Console.ReadKey();
        }
    }

    internal interface IFunction
    {
        double F(double x);
    }

    internal class Function : IFunction
    {
        public double F(double x)
        {
            return x;
        }
    }

    internal class QuadFunction : IFunction
    {
        public double F(double x)
        {
            return Math.Pow(x, 2);
        }
    }
}
