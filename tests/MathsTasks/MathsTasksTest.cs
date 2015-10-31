using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hk.MathsTasks.Tests
{
    [TestClass]
    public class MathsTasksTest
    {
        //TODO: Need to optimize this test
        [TestMethod]
        public void TestCalculatePrimeNumbers()
        {
            List<int> primes = MathsTasks.CalculatePrimeNumbers(50);

            foreach (int prime in primes)
            {
                Console.WriteLine(prime);
            }
        }

        [TestMethod]
        public void TestNthFibonacciNumber()
        {
            Console.WriteLine(MathsTasks.NthFibonacciNumber(6));
        }

        [TestMethod]
        public void TestMissingNumberInOrderedList()
        {
            Console.WriteLine(MathsTasks.MissingNumberInSequence(new[] { 0,1, 2, 3, 4, 5, 7, 8, 9 }));
        }
    }
}
