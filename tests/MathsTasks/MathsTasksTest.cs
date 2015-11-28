using System;
using hk.Common.Tests;
using NUnit.Framework;

namespace hk.MathsTasks.Tests
{
    [TestFixture, TimerAction("MathsTasksTest")]
    public class MathsTasksTest
    {
        //TODO: Need to optimize this test
        [Test]
        public void TestCalculatePrimeNumbers()
        {
            var primes = MathsTasks.CalculatePrimeNumbers(50);

            foreach (var prime in primes)
            {
                Console.WriteLine(prime);
            }
        }

        [Test]
        public void TestMissingNumberInOrderedList()
        {
            Console.WriteLine(MathsTasks.MissingNumberInSequence(new[] {0, 1, 2, 3, 4, 5, 7, 8, 9}));
        }

        [Test]
        public void TestNthFibonacciNumber()
        {
            Console.WriteLine(MathsTasks.NthFibonacciNumber(6));
        }
    }
}