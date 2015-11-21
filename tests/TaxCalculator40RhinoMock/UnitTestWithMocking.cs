using NUnit.Framework;
using Rhino.Mocks;

namespace hk.TaxCalculator.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class UnitTestWithMocking
    {
        [Test]
        public void Test1()
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
