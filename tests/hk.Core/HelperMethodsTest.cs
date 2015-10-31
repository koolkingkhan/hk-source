using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
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
            string xml = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\..\Oxford Uni\hk-msc\PROJECT\kip-test-harness\src\main\resources\settings\settings.xml");
            string xsd = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\..\Oxford Uni\hk-msc\PROJECT\kip-test-harness\src\main\resources\settings\settings.xsd");
            Assert.IsTrue(File.Exists(xml));
            Assert.IsTrue(File.Exists(xsd));
            Assert.IsTrue(HelperMethods.ValidateXml(xml, xsd, string.Empty));
        }

        [TestMethod]
        public void TestSerializeSettings()
        {
            string xml = Path.GetFullPath(@"..\..\..\..\..\Oxford Uni\hk-msc\PROJECT\kip-test-harness\src\main\resources\settings\settings.xml");
            Assert.IsTrue(File.Exists(xml));
            Settings settings;

            using (Stream reader = File.Open(xml, FileMode.Open))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);

                using (XmlTextReader stream = new XmlTextReader(new StringReader(doc.InnerXml)))
                {
                    Assert.IsTrue(HelperMethods.TryDeserialize(stream, out settings));

                    foreach (Table table in settings.Table)
                    {
                        foreach (Rule rule in table.TabularRule)
                        {
                            if (table.RuleGroupName != ruleGroupsEnums.None)
                            {
                                ApplyRuleGroupValue(rule, rule.RuleGroupName);
                            }
                            else
                            {
                                var rulGroupName = rule.Argument.FirstOrDefault(g => g.IdSpecified && g.Id == keyEnums.ruleGroupName);
                                if (rulGroupName != null)
                                {
                                    var value = GetCode<ruleGroupsEnums>(rulGroupName.Value);
                                    ApplyRuleGroupValue(rule, value);
                                }
                                else if (table.Name.Equals("Modification Rules", StringComparison.OrdinalIgnoreCase))
                                {
                                    ApplyRuleGroupValue(rule, ruleGroupsEnums.None);
                                }
                            }
                        }
                    }
                }
            }

            Assert.IsTrue(HelperMethods.TrySerialize(settings, xml));
        }

        public static string GetXmlAttrNameFromEnumValue<T>(T pEnumVal)
        {
            // http://stackoverflow.com/q/3047125/194717
            Type type = pEnumVal.GetType();
            FieldInfo info = type.GetField(Enum.GetName(typeof(T), pEnumVal));
            XmlEnumAttribute att = (XmlEnumAttribute)info.GetCustomAttributes(typeof(XmlEnumAttribute), false)[0];
            //If there is an xmlattribute defined, return the name

            return att.Name;
        }
        public static T GetCode<T>(string value)
        {
            // http://stackoverflow.com/a/3073272/194717
            foreach (object o in System.Enum.GetValues(typeof(T)))
            {
                T enumValue = (T)o;
                if (GetXmlAttrNameFromEnumValue<T>(enumValue).Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    return (T)o;
                }
            }

            throw new ArgumentException("No XmlEnumAttribute code exists for type " + typeof(T).ToString() + " corresponding to value of " + value);
        }

        private static void ApplyRuleGroupValue(Rule rule, ruleGroupsEnums ruleGroup)
        {
            switch (ruleGroup)
            {
                case ruleGroupsEnums.Setup:
                    rule.RuleId += 1000;
                    break;
                case ruleGroupsEnums.HealthCheck:
                    rule.RuleId += 3000;
                    break;
                case ruleGroupsEnums.EqReferenceDataCheck:
                    rule.RuleId += 4000;
                    break;
                case ruleGroupsEnums.FiReferenceDataCheck:
                    rule.RuleId += 5000;
                    break;
                case ruleGroupsEnums.EqAvailabilityRestrictions:
                    rule.RuleId += 6000;
                    break;
                case ruleGroupsEnums.FiAvailabilityRestrictions:
                    rule.RuleId += 7000;
                    break;
                case ruleGroupsEnums.EqInstrumentRestrictions:
                    rule.RuleId += 8000;
                    break;
                case ruleGroupsEnums.FiInstrumentRestrictions:
                    rule.RuleId += 9000;
                    break;
                case ruleGroupsEnums.CommonOrderChecks:
                    rule.RuleId += 10000;
                    break;
                case ruleGroupsEnums.EqWarmsTrades:
                    rule.RuleId += 11000;
                    break;
                case ruleGroupsEnums.EqBigTickets:
                    rule.RuleId += 12000;
                    break;
                case ruleGroupsEnums.EqSmallTickets:
                    rule.RuleId += 13000;
                    break;
                case ruleGroupsEnums.EqGeneralTickets:
                    rule.RuleId += 14000;
                    break;
                case ruleGroupsEnums.OfferRestrictions:
                    rule.RuleId += 15000;
                    break;
                case ruleGroupsEnums.EqCounterpartyRestrictions:
                    rule.RuleId += 16000;
                    break;
                case ruleGroupsEnums.FiCounterpartyRestrictions:
                    rule.RuleId += 17000;
                    break;
                case ruleGroupsEnums.EquiLendOrderChecks:
                    rule.RuleId += 18000;
                    break;
                case ruleGroupsEnums.BondLendOrderChecks:
                    rule.RuleId += 19000;
                    break;
                case ruleGroupsEnums.EqMaelstromOrderChecks:
                    rule.RuleId += 20000;
                    break;
                case ruleGroupsEnums.FiMaelstromOrderChecks:
                    rule.RuleId += 21000;
                    break;
                case ruleGroupsEnums.Highlight:
                    rule.RuleId += 22000;
                    break;
                case ruleGroupsEnums.None:
                    rule.RuleId += 23000;
                    break;
                case ruleGroupsEnums.FinalDecisions:
                    rule.RuleId += 25000;
                    break;
            }
        }
    }
}
