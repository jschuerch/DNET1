using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Sieve
{
    class SieveOfEratosthenes
    {
        static void Main(string[] args)
        {
            var sizeOfSieve = GetSizeOfSieve(args);
            var sieve = Erastosthenes(sizeOfSieve);

            Console.WriteLine("\nSieve of Eratosthenes:");
            for (int i = 1; i <= sizeOfSieve; i++)
            {
                Console.Write("{0, -12}", sieve[i]);
                if (i % 10 == 0)
                    Console.WriteLine();
            }

            PrintPrimeNumbers(sieve);

            Console.Write("\n\n\nPress enter to close the window...");
            Console.In.ReadLine();
        }

        public static int GetSizeOfSieve(string[] args)
        {
            string input;
            if (args.Length > 0)
            {
                input = args[0];
                Console.WriteLine("Size of sieve: " + input);
            }
            else
            {
                Console.WriteLine("Enter size of sieve:");
                input = Console.In.ReadLine();
            }

            var sizeOfSieve = Int32.Parse(input);
            if (sizeOfSieve < 1)
            {
                Console.Error.WriteLine("Size of sieve has to be a positive number.");
                Environment.Exit(0);
            }

            return sizeOfSieve;
        }

        public static PrimeType[] Erastosthenes(int size)
        {
            var sieve = new PrimeType[size + 1];
            var threshold = Math.Sqrt(size);

            sieve[0] = PrimeType.NotPrime;
            sieve[1] = PrimeType.NotPrime;
            for (int i = 2; i <= threshold; i++)
            {
                if (sieve[i] == PrimeType.NotPrime)
                    continue;

                for (int j = i+1; j <= size; j++)
                {
                    if (j % i == 0)
                    {
                        sieve[j] = PrimeType.NotPrime;
                    }
                }
            }

            return sieve;
        }

        public static void PrintPrimeNumbers(PrimeType[] sieve)
        {
            var primeNumberArray = ExtractPrimeNumbersArray(sieve);
            Console.WriteLine("\n\nArray of Primes:");
            int cnt = 1;
            foreach (var prime in primeNumberArray)
            {
                Console.Write("{0, -6}", prime);
                if (cnt++ % 10 == 0)
                    Console.WriteLine();
            }

            var primeNumberList = ExtractPrimeNumbersList(sieve);
            Console.WriteLine("\n\nList of Primes:");
            cnt = 1;
            foreach (var prime in primeNumberList)
            {
                Console.Write("{0, -6}", prime);
                if (cnt++ % 10 == 0)
                    Console.WriteLine();
            }

            var primeNumberDictionary = ExtractPrimeNumbersDictionary(sieve);
            Console.WriteLine("\n\nDictionary of Primes:");
            cnt = 1;
            foreach (var prime in primeNumberDictionary)
            {
                Console.Write("{0, 4} -> {1, -6}", prime.Key, prime.Value);
                if (cnt++ % 10 == 0)
                    Console.WriteLine();
            }
        }

        public static int[] ExtractPrimeNumbersArray(PrimeType[] sieve)
        {
            var primeNumbers = new int[sieve.Count(n => n == PrimeType.Prime)];
            var index = 0;
            for(int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i] == PrimeType.Prime)
                    primeNumbers[index++] = i;
            }

            return primeNumbers;
        }

        public static IList<int> ExtractPrimeNumbersList(PrimeType[] sieve)
        {
            var primeNumbers = new List<int>();

            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i] == PrimeType.Prime)
                    primeNumbers.Add(i);
            }

            return primeNumbers;
        }

        public static IDictionary<int, int> ExtractPrimeNumbersDictionary(PrimeType[] sieve)
        {
            var primeNumbers = new Dictionary<int, int>();
            var index = 0;
            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i] == PrimeType.Prime)
                    primeNumbers.Add(index++, i);
            }

            return primeNumbers;
        }
    }

    enum PrimeType { Prime = 0, NotPrime = 1}
}
