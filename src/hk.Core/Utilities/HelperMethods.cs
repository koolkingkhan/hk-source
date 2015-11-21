using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace hk.Core.Utilities
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

        public static bool TryDeserialize<TMyType>(Stream stream, out TMyType t)
        {
            t = default(TMyType);

            if (null == stream)
            {
                return false;
            }

            bool success = false;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(TMyType));
                t = (TMyType)deserializer.Deserialize(stream);
                success = true;
            }
            catch (InvalidOperationException e)
            {
                string errorMessage = string.Format("Failed to deserialize object, error: {0}", e.Message);
                Debug.WriteLine(errorMessage);
            }

            return success;
        }

        public static bool TrySerialize<TMyType>(TMyType t, string location)
        {
            if (null == t)
            {
                return false;
            }

            try
            {
                var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };

                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                using (var writer = XmlWriter.Create(location, settings))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(TMyType));
                    xml.Serialize(writer, t, namespaces);
                    return true;
                } 
            }
            catch (Exception)
            {
                return false;
            }
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
