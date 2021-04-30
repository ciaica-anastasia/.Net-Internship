using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OverloadingAndInterfaces.Primes
{
    class Primes
    {
        private long min;
        private long max;

        public Primes() : this(2, 100)
        {
        }

        public Primes(long minimum, long maximum)
        {
            if (min < 2)
            {
                min = 2;
            }
            min = minimum;
            max = maximum;
        }

        public IEnumerator GetEnumerator() //you have to create an instance
        {
            for (long possiblePrime = min; possiblePrime <= max; possiblePrime++)
            {
                bool isPrime = true;
                for (long possibleFactor = 2; possibleFactor <= (long)Math.Floor(Math.Sqrt(possiblePrime)); possibleFactor++)
                {
                    long remainderAfterDivision = possiblePrime % possibleFactor;
                    if (remainderAfterDivision == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    yield return possiblePrime;
                }
            }
        }
        
        public IEnumerable<long> CustomEnumerable()
        {
            for (long possiblePrime = min; possiblePrime <= max; possiblePrime++)
            {
                bool isPrime = true;
                for (long possibleFactor = 2; possibleFactor <= (long)Math.Floor(Math.Sqrt(possiblePrime)); possibleFactor++)
                {
                    long remainderAfterDivision = possiblePrime % possibleFactor;
                    if (remainderAfterDivision == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    yield return possiblePrime;
                }
            }
        }
        
        //Custom method returning IEnumerable is more common
    }
}
