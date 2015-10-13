using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace hk.TaxCalculator40.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTestWithMocking
    {
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

            ITaxCalculator mock = MockRepository.GenerateStub<ITaxCalculator>();
            mock.Stub(t => t.GetTax(Arg<int>.Is.Anything)).Return(5.0M);
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
