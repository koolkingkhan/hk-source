using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using hk.Common.Utilities;
using NUnit.Framework;

namespace hk.Common.Tests
{
    [TestFixture, TimerAction("HelperMethodsTest")]
    public class HelperMethodsTest
    {
        private static readonly string XmlPath = Path.GetFullPath(@"resources\settings.xml");
        private static readonly string XsdPath = Path.GetFullPath(@"resources\settings.xsd");

        [Ignore("Ignore this test")]
        public void TestSerializeSettings()
        {
            Settings settings;

            using (var stream = new FileStream(XmlPath, FileMode.Open))
            {
                Assert.IsTrue(HelperMethods.TryDeserialize(stream, out settings));

                foreach (var table in settings.Table)
                {
                    foreach (var rule in table.TabularRule)
                    {
                        if (table.RuleGroupName != RuleGroups.None)
                        {
                            ApplyRuleGroupValue(rule, rule.RuleGroupName);
                        }
                        else
                        {
                            var rulGroupName =
                                rule.Argument.FirstOrDefault(g => g.IdSpecified && g.Id == Keys.RuleGroupName);
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
            var type = pEnumVal.GetType();
            var info = type.GetField(Enum.GetName(typeof (T), pEnumVal));
            var att = (XmlEnumAttribute) info.GetCustomAttributes(typeof (XmlEnumAttribute), false)[0];

            return att.Name;
        }

        public static T GetCode<T>(string value)
        {
            foreach (var o in Enum.GetValues(typeof (T)))
            {
                var enumValue = (T) o;
                if (GetXmlAttrNameFromEnumValue(enumValue).Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    return (T) o;
                }
            }

            throw new ArgumentException("No XmlEnumAttribute code exists for type " + typeof (T) +
                                        " corresponding to value of " + value);
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

        [Test, Ignore("")]
        public void TestDeserializeSettings()
        {
            using (var stream = new FileStream(XmlPath, FileMode.Open))
            {
                Settings settings;
                Assert.IsTrue(HelperMethods.TryDeserialize(stream, out settings));
            }
        }

        [Test]
        public void TestMissingNumber()
        {
            int[] test = {1, 2, 3, 4, 6};
            var expected = 5;
            var actual = HelperMethods.MissingNumberInSequence(test);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestMissingNumber2()
        {
            int[] test = {0, 1, 2, 3, 4, 6};
            var expected = 5;
            var actual = HelperMethods.MissingNumberInSequence(test);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestReverseString()
        {
            var test = "qwerty";
            var expected = "ytrewq";
            var actual = HelperMethods.ReverseString(test);

            Assert.IsTrue(expected.Equals(actual), actual);
        }

        [Test, Ignore("")]
        public void TestValidateXml()
        {
            string failureMessage;
            Assert.IsTrue(HelperMethods.ValidateXml(XmlPath, XsdPath, string.Empty, out failureMessage), failureMessage);
        }
    }
}