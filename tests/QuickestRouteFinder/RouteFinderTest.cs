using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using hk.Core.Tests;
using hk.QuickestRouteFinder.Interfaces;
using NUnit.Framework;

namespace hk.QuickestRouteFinder.Tests
{
    /// <summary>
    ///This is a test class for IRouteFinderTest and is intended
    ///to contain all IRouteFinderTest Unit Tests
    ///</summary>
    [TestFixture, ConsoleAction("RouteFinderTest")]
    public class RouteFinderTest
    {
        private const string TestFileName = "hk.QuickestRouteFinder.Tests.TestFiles.StationRoutesAndTimes.xml";

        /// <summary>
        ///A test for GetStations
        ///</summary>
        [Test]
        public void GetStationsTest()
        {
            IRouteFinder target = CreateIRouteFinder();
            IEnumerable<string> expected = new List<string>
                                             {
                                                 "a", "b", "c", "d", "e"
                                             };

            var actual = target.Stations.ToList();

            foreach (string station in actual)
            {
                Assert.IsTrue(expected.Contains(station));
            }
        }

        /// <summary>
        ///A test for invalid departure station
        ///</summary>
        [Test]
        public void InvalidFrom()
        {
            const int expected = -1;

            int actual = CreateIRouteFinder().ShortestTime("Z", "B");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for invalid departure station
        ///</summary>
        [Test]
        public void InvalidTo()
        {
            const int expected = -1;

            int actual = CreateIRouteFinder().ShortestTime("A", "Z");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for invalid departure station
        ///</summary>
        [Test]
        public void InvalidFromTo()
        {
            const int expected = -1;

            int actual = CreateIRouteFinder().ShortestTime("yyy", "zzz");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetShortestTime from A to A
        ///Should be viewed as not departing 
        ///</summary>
        [Test]
        public void GetShortestTimeTest_AA()
        {
            const int expected = 0;

            int actual = CreateIRouteFinder().ShortestTime("A", "A");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetShortestTime from A to B
        ///</summary>
        [Test]
        public void GetShortestTimeTest_AB()
        {
            const int expected = 3;

            int actual = CreateIRouteFinder().ShortestTime("a", "b");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetShortestTime from A to C
        ///</summary>
        [Test]
        public void GetShortestTimeTest_AC()
        {
            const int expected = 10;

            int actual = CreateIRouteFinder().ShortestTime("A", "c");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetShortestTime from A to E
        ///</summary>
        [Test]
        public void GetShortestTimeTest_AE()
        {
            const int expected = 13;
            
            int actual = CreateIRouteFinder().ShortestTime("a", "E");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetShortestTime from B to D
        ///</summary>
        [Test()]
        public void GetShortestTimeTest_BD()
        {
            const int expected = 9;

            int actual = CreateIRouteFinder().ShortestTime("B", "D");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetShortestTime from B to E
        ///</summary>
        [Test]
        public void GetShortestTimeTest_BE()
        {
            const int expected = 10;

            int actual = CreateIRouteFinder().ShortestTime("B", "E");
            Assert.AreEqual(expected, actual);
        }

        internal virtual IRouteFinder CreateIRouteFinder()
        {
            IRouteFinder target = new RouteFinder(GetTestDocument());
            return target;
        }

        private XmlDocument GetTestDocument()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(TestFileName))
            {
                if (null != stream)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(stream);
                    return doc;
                }
            }

            return null;
        }
    }
}
