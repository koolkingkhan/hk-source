using hk.Common.Tests;
using Moq;
using NUnit.Framework;

namespace hk.TaxCalculator.Tests
{
    /// <summary>
    ///     Summary description for UnitTest1
    /// </summary>
    [TestFixture, TimerAction("UnitTestWithMocking")]
    public class UnitTestWithMocking
    {
        [Test]
        public void Test1()
        {
            const int expected = 30;

            var mock = new Mock<ITaxCalculator>();
            mock.Setup(t => t.GetTax(It.IsAny<decimal>())).Returns(5.0M);
            var prod = new Product
            {
                Id = 123,
                Name = "Something",
                RawPrice = 25.0M
            };

            var calculatedTax = prod.GetPriceWithTax(mock.Object);

            Assert.AreEqual(expected, calculatedTax);
        }
    }
}