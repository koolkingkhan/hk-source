using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hk.TaxCalculator40.Tests
{
    /// <summary>
    /// Summary description for UnitTestWithoutMocking
    /// </summary>
    [TestClass]
    public class UnitTestWithoutMocking
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            const int expected = 30;
            ITaxCalculator mock = new TaxCalculator();

            Product prod = new Product
            {
                Id = 123,
                Name = "Something",
                RawPrice = 25.0M
            };

            decimal calculatedTax = prod.GetPriceWithTax(mock);
            
            Assert.AreEqual(expected, calculatedTax);
        }
    }
}
