using System;
using System.Linq;

namespace hk.Core
{
    public class HelperMethods
    {
        public static String ReverseString(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            char[] c = str.ToCharArray();
            char[] d = new char[c.Length];

            int end = c.Length-1;
            for (int i = 0; i < c.Length; i++)
            {
                d[i] = c[end--];
            }
            return new string(d);
        }

        public static int MissingNumberInSequence(int[] array)
        {
            int actualSum = array.Sum();
            int firstNumber = array[0];
            int lastNumber = array[array.Length - 1];

            int totalSumOfNumbers = (lastNumber * (lastNumber + 1)) / 2;

            return totalSumOfNumbers - actualSum;
        }
    }
}
