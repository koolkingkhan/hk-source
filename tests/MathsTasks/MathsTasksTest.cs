using System;
using System.Collections.Generic;
using hk.Core.Tests;
using NUnit.Framework;

namespace hk.MathsTasks.Tests
{
    [TestFixture, ConsoleAction("MathsTasksTest")]
    public class MathsTasksTest
    {
        //TODO: Need to optimize this test
        [Test]
        public void TestCalculatePrimeNumbers()
        {
            List<int> primes = MathsTasks.CalculatePrimeNumbers(50);

            foreach (int prime in primes)
            {
                Console.WriteLine(prime);
            }
        }

        [Test]
        public void TestNthFibonacciNumber()
        {
            Console.WriteLine(MathsTasks.NthFibonacciNumber(6));
        }

        [Test]
        public void TestMissingNumberInOrderedList()
        {
            Console.WriteLine(MathsTasks.MissingNumberInSequence(new[] { 0,1, 2, 3, 4, 5, 7, 8, 9 }));
        }
    }
}
