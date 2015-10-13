using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hk.Core.Tests
{
    [TestClass]
    public class HelperMethodsTest
    {
        private Stopwatch _stopwatch;

        public TestContext TestContext { get; set; }
        

        [TestInitialize]
        public void Setup()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine("{0}: {1}", TestContext.TestName, _stopwatch.Elapsed);
        }

        [TestMethod]
        public void TestReverseString()
        {
            string test = "qwerty";
            string expected = "ytrewq";
            string actual = HelperMethods.ReverseString(test);

            Assert.IsTrue(expected.Equals(actual), actual);
        }

        [TestMethod]
        public void TestMissingNumber()
        {
            int[] test = new int[]{1,2,3,4,6};
            int expected = 5;
            int actual = HelperMethods.MissingNumberInSequence(test);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMissingNumber2()
        {
            int[] test = new int[] { 0, 1, 2, 3, 4, 6 };
            int expected = 5;
            int actual = HelperMethods.MissingNumberInSequence(test);

            Assert.AreEqual(expected, actual);
        }
    }
}
