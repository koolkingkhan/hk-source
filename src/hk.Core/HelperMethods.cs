using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;

namespace hk.Core
{
    public class HelperMethods
    {
        public static String ReverseString(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            char[] c = str.ToCharArray();
            char[] d = new char[c.Length];

            int end = c.Length-1;
            for (int i = 0; i < c.Length; i++)
            {
                d[i] = c[end--];
            }
            return new string(d);
        }

        public static int MissingNumberInSequence(int[] array)
        {
            int actualSum = array.Sum();
            int firstNumber = array[0];
            int lastNumber = array[array.Length - 1];

            int totalSumOfNumbers = (lastNumber * (lastNumber + 1)) / 2;

            return totalSumOfNumbers - actualSum;
        }

        public static bool ValidateXml(string xml, string xsd, string targetNamespace)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(targetNamespace, xsd);

            XDocument doc = XDocument.Load(xml);
            string msg = "";
            doc.Validate(schemas, (o, e) =>
            {
                msg += e.Message + Environment.NewLine;
            });
            return string.IsNullOrEmpty(msg);
        }
    }
}
