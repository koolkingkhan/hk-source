using hk.Common.Tests;
using NUnit.Framework;

namespace hk.TelephonePermutations.Tests
{
    [TestFixture, TimerAction("PermutationsTest")]
    public class PermutationsTest
    {
        [Test]
        public void Test1()
        {
            Permutations.PrintPhoneNumberPermutations("02076927361");
        }
    }
}