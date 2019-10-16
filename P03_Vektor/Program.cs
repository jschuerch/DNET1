using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_Vector
{
    class Program
    {
        private static void test()
        {
            Vector a = new Vector(1, 2, 3);
            Console.WriteLine("a = \t\t\t" + a);
            Vector b = new Vector(4, 5, 6);
            Console.WriteLine("b = \t\t\t" + b);
            Vector c = a * b;
            Console.WriteLine("a * b = \t\t" + c);
            c = a + b;
            Console.WriteLine("a + b = \t\t" + c);
            c = a - b;
            Console.WriteLine("a - b = \t\t" + c);

            Vector d = 10;
            Console.WriteLine("d = \t\t\t" + d);

            double betragA = (double)a;
            Console.WriteLine("|a| = \t\t\t" + a);

            Vector aCopy = new Vector(1, 2, 3);

            Console.WriteLine("a == aCopy : \t\t" + (a == aCopy));
            Console.WriteLine("a != b : \t\t" + (a != b));
            Console.WriteLine("b == c : \t\t" + (b == c));
            Console.WriteLine("aCopy.Equals(a) : \t" + aCopy.Equals(a));
            Console.WriteLine();
        }

        static private void calculateMaxvalocity()
        {
            // 1. Drehung der Erde um ihre Achse
            var omega = new Vector(x: 2 * Math.PI / (24 * 60 * 60));
            var radius = new Vector(y: 6370);
            var drehung = omega * radius;
            // 2. Rotation der Erde um die Sonne
            omega = new Vector(x: 2 * Math.PI / (365.25 * 24 * 60 * 60));
            radius = new Vector(y: 149.6E6);
            var rotationErde = omega * radius;
            // 3. Rotation der Sonne um das galaktische Zentrum
            omega = new Vector(x: 2 * Math.PI / (225E6 * 365.25 * 24 * 60 * 60));
            radius = new Vector(y: 25000 * 9.46E12);
            var rotationSonne = omega * radius;

            var maxVelocity = drehung + rotationErde + rotationSonne;
            Console.WriteLine("Die Maximalgeschwindigkeit ist: " + maxVelocity.Norm()); 
            // Result: 239.527376526468
        }

        static void Main(string[] args)
        {
            //test();

            calculateMaxvalocity();

            Console.ReadKey();
        }
    }
}
