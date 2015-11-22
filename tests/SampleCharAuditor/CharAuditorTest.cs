using NUnit.Framework;

namespace hk.SampleCharAuditor.Tests
{
    
    public class Foo
    {
        public string AppendedString(ICharAuditor auditor)
        {
            return auditor.GetMostPrevalentChar("asadnkdfnksfdtaareaahkdsnklsnaadsadasd") + "_appended";
        }
    }


    /// <summary>
    /// Summary description for CharAuditorTest
    /// </summary>
    [TestFixture]
    public class CharAuditorTest
    {
        [Test]
        public void TestGetMostPrevalentChar()
        {
            var mock = new CharAuditor();

            Assert.IsTrue(mock.GetMostPrevalentChar("asadnbbbkdfnkbbbsfdtaareabbbahkdsnklsbbbnaadsadabbbsd") == "b");
        }
    }
}
