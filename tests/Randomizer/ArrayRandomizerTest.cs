using System.Linq;
using hk.Common.Tests;
using NUnit.Framework;

namespace hk.Randomizer.Tests
{
    [TestFixture, TimerAction("ArrayRandomizerTest")]
    public class ArrayRandomizerTest
    {
        [Test]
        public void TestGetRandomizedArray()
        {
            //As we are using numbers from 1 .. 1000 we can use the formula to calculate the sum of all integers from 1 to N.
            //i.e. N * (N + 1) / 2
            //Testing to see if the sum from the randomised array matches the formula confirms we have not omitted or repeated any integer values.
            const int expectedSum = 1000*(1000 + 1)/2;
            const int start = 1;
            const int size = 1000;
            var sut = ArrayRandomizer.GetRandomizedArray(start, size);

            var actualSum = sut.Sum();

            Assert.IsTrue(expectedSum == actualSum);

            //Use this as a simple check to ensure that the array has been randomized.
            //i.e. Find the first element in the array that does not match an ordered array
            Assert.IsTrue(sut.Where((t, i) => t != i + start).Any());
        }
    }
}