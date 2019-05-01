using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab03
{
	public static class MathStuff
	{
		/// <summary>
		/// Determines the approximate number of primes less than the given number
		/// </summary>
		/// <param name="x">Number to approximate number of primes below it</param>
		/// <returns>Approximate number of primes</returns>
		public static ulong ApproximateNumberOfPrimes(ulong x)
		{
		
            double num = (x / (Math.Log(x, Math.E) - 1)) * 1.05;
            return (ulong)num;
		}


		/// <summary>
		/// Brute force algorithm to determine if a number is prime
		/// </summary>
		/// <param name="number">Number to test</param>
		/// <returns>true if prime, false otherwise</returns>
		public static bool IsPrime(ulong number)
		{
            
            if (number <= 1) return false; //0 or 1 cannot be prime
            if ((number == 2) || (number == 3) || (number ==5)) return true; //2,3,5 are prime numbers;
            if ((number & 1) == 0) return false; //even number cannot be prime
            if ((number % 5) == 0) return false; //multiplier of 5 cannot be prime
            ulong max = (uint)Math.Sqrt(number);

            int count = 3;

            for (ulong i = 3; i<=max; i+=2)
            {
                if (count == 4)
                {
                    count = 0;
                    continue; //skip when count is a multiplier of 5
                }

                ++count;

                if (number % i == 0)
                {
                    return false;
                }
            }

			return true;
		}
	}
}
