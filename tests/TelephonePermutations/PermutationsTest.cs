using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hk.TelephonePermutations.Tests
{
    [TestClass]
    public class PermutationsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            TelephonePermutations.Permutations.PrintPhoneNumberPermutations("02076927361");
        }
    }
}
