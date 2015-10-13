using System.Collections;
using System.Collections.Generic;

namespace hk.MathsTasks
{
    public class MathsTasks
    {
        public static List<int> CalculatePrimeNumbers(int arg_max_prime)
        {
            BitArray al = new BitArray(arg_max_prime, true);

            int lastprime = 1;
            int lastprimeSquare = 1;

            while (lastprimeSquare <= arg_max_prime)
            {
                lastprime++;

                while (!(bool)al[lastprime])
                    lastprime++;

                lastprimeSquare = lastprime * lastprime;

                for (int i = lastprimeSquare; i < arg_max_prime; i += lastprime)
                    if (i > 0)
                        al[i] = false;
            }

            List<int> sieve_2_return = new List<int>();

            for (int i = 2; i < arg_max_prime; i++)
                if (al[i])
                    sieve_2_return.Add(i);

            return sieve_2_return;
        }

        public static int NthFibonacciNumber(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return (NthFibonacciNumber(n - 1) + NthFibonacciNumber(n - 2));
        }

        public static int MissingNumberInSequence(int[] arr)
        {
            int sum = 0;
            bool containsZero=false;
            foreach (int i in arr)
            {
                if (!containsZero && i.CompareTo(0)==0)
                {
                    containsZero = true;
                }

                sum += i;
            }

            //Does this list contain 0?
            //The sum of Natural Numbers (1,2,3,4,5...n) is N(N+1)/2
            int totalNumbers = containsZero ? arr.Length : arr.Length + 1;

            int total = (totalNumbers * (totalNumbers + 1)) / 2;

            int missingNumber = total - sum;

            return missingNumber;
        }
    }
}
