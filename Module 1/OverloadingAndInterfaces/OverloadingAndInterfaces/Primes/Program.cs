using System;

namespace OverloadingAndInterfaces.Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            var primes = new Primes(1, 5);

            foreach (var prime in primes.CustomEnumerable())
            {
                Console.WriteLine(prime); //вывод простых чисел от 1 до 5
            }
        }
    }
}
