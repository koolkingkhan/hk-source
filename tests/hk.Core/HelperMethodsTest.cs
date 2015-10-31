using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hk.Core.Tests
{
    [TestClass]
    public class HelperMethodsTest
    {
        private Stopwatch _stopwatch;
        private static readonly string XmlPath = Path.GetFullPath(@"..\..\..\..\..\Oxford Uni\hk-msc\PROJECT\kip-test-harness\src\main\resources\settings\settings.xml");
        private static readonly string XsdPath = Path.GetFullPath(@"..\..\..\..\..\Oxford Uni\hk-msc\PROJECT\kip-test-harness\src\main\resources\settings\settings.xsd");

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialise(TestContext context)
        {
            Assert.IsTrue(File.Exists(XmlPath));
            Assert.IsTrue(File.Exists(XsdPath));
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
        }

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
            Debug.WriteLine("{0}: {1}", TestContext.TestName, _stopwatch.Elapsed);
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
            int[] test = new int[] { 1, 2, 3, 4, 6 };
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

        [TestMethod]
        public void TestValidateXml()
        {
            Assert.IsTrue(HelperMethods.ValidateXml(XmlPath, XsdPath, string.Empty));
        }

        [TestMethod]
        public void TestDeserializeSettings()
        {
            using (FileStream stream = new FileStream(XmlPath, FileMode.Open))
            {
                Settings settings;
                Assert.IsTrue(HelperMethods.TryDeserialize(stream, out settings));
            }
        }

        [TestMethod, Ignore]
        public void TestSerializeSettings()
        {
            Settings settings;

            using (FileStream stream = new FileStream(XmlPath, FileMode.Open))
            {
                Assert.IsTrue(HelperMethods.TryDeserialize(stream, out settings));

                foreach (Table table in settings.Table)
                {
                    foreach (Rule rule in table.TabularRule)
                    {
                        if (table.RuleGroupName != RuleGroups.None)
                        {
                            ApplyRuleGroupValue(rule, rule.RuleGroupName);
                        }
                        else
                        {
                            var rulGroupName = rule.Argument.FirstOrDefault(g => g.IdSpecified && g.Id == Keys.RuleGroupName);
                            if (rulGroupName != null)
                            {
                                var value = GetCode<RuleGroups>(rulGroupName.Value);
                                ApplyRuleGroupValue(rule, value);
                            }
                            else if (table.Name.Equals("Modification Rules", StringComparison.OrdinalIgnoreCase))
                            {
                                ApplyRuleGroupValue(rule, RuleGroups.None);
                            }
                        }
                    }
                }
            }

            Assert.IsTrue(HelperMethods.TrySerialize(settings, XmlPath));
        }

        public static string GetXmlAttrNameFromEnumValue<T>(T pEnumVal)
        {
            Type type = pEnumVal.GetType();
            FieldInfo info = type.GetField(Enum.GetName(typeof(T), pEnumVal));
            XmlEnumAttribute att = (XmlEnumAttribute)info.GetCustomAttributes(typeof(XmlEnumAttribute), false)[0];

            return att.Name;
        }

        public static T GetCode<T>(string value)
        {
            foreach (object o in Enum.GetValues(typeof(T)))
            {
                T enumValue = (T)o;
                if (GetXmlAttrNameFromEnumValue(enumValue).Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    return (T)o;
                }
            }

            throw new ArgumentException("No XmlEnumAttribute code exists for type " + typeof(T) + " corresponding to value of " + value);
        }

        private static void ApplyRuleGroupValue(Rule rule, RuleGroups ruleGroup)
        {
            switch (ruleGroup)
            {
                case RuleGroups.Setup:
                    rule.RuleId += 1000;
                    break;
                case RuleGroups.HealthCheck:
                    rule.RuleId += 3000;
                    break;
                case RuleGroups.EqReferenceDataCheck:
                    rule.RuleId += 4000;
                    break;
                case RuleGroups.FiReferenceDataCheck:
                    rule.RuleId += 5000;
                    break;
                case RuleGroups.EqAvailabilityRestrictions:
                    rule.RuleId += 6000;
                    break;
                case RuleGroups.FiAvailabilityRestrictions:
                    rule.RuleId += 7000;
                    break;
                case RuleGroups.EqInstrumentRestrictions:
                    rule.RuleId += 8000;
                    break;
                case RuleGroups.FiInstrumentRestrictions:
                    rule.RuleId += 9000;
                    break;
                case RuleGroups.CommonOrderChecks:
                    rule.RuleId += 10000;
                    break;
                case RuleGroups.EqWarmsTrades:
                    rule.RuleId += 11000;
                    break;
                case RuleGroups.EqBigTickets:
                    rule.RuleId += 12000;
                    break;
                case RuleGroups.EqSmallTickets:
                    rule.RuleId += 13000;
                    break;
                case RuleGroups.EqGeneralTickets:
                    rule.RuleId += 14000;
                    break;
                case RuleGroups.OfferRestrictions:
                    rule.RuleId += 15000;
                    break;
                case RuleGroups.EqCounterpartyRestrictions:
                    rule.RuleId += 16000;
                    break;
                case RuleGroups.FiCounterpartyRestrictions:
                    rule.RuleId += 17000;
                    break;
                case RuleGroups.EquiLendOrderChecks:
                    rule.RuleId += 18000;
                    break;
                case RuleGroups.BondLendOrderChecks:
                    rule.RuleId += 19000;
                    break;
                case RuleGroups.EqMaelstromOrderChecks:
                    rule.RuleId += 20000;
                    break;
                case RuleGroups.FiMaelstromOrderChecks:
                    rule.RuleId += 21000;
                    break;
                case RuleGroups.Highlight:
                    rule.RuleId += 22000;
                    break;
                case RuleGroups.None:
                    rule.RuleId += 23000;
                    break;
                case RuleGroups.FinalDecisions:
                    rule.RuleId += 25000;
                    break;
            }
        }
    }
}
