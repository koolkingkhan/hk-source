using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace hk.Common.Utilities
{
    public class HelperMethods
    {
        public static string ReverseString(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            var c = str.ToCharArray();
            var d = new char[c.Length];

            var end = c.Length - 1;
            for (var i = 0; i < c.Length; i++)
            {
                d[i] = c[end--];
            }
            return new string(d);
        }

        public static int MissingNumberInSequence(int[] array)
        {
            var actualSum = array.Sum();
            var firstNumber = array[0];
            var lastNumber = array[array.Length - 1];

            var totalSumOfNumbers = lastNumber*(lastNumber + 1)/2;

            return totalSumOfNumbers - actualSum;
        }

        public static bool TryDeserialize<TMyType>(Stream stream, out TMyType t)
        {
            t = default(TMyType);

            if (null == stream)
            {
                return false;
            }

            var success = false;

            try
            {
                var deserializer = new XmlSerializer(typeof (TMyType));
                t = (TMyType) deserializer.Deserialize(stream);
                success = true;
            }
            catch (InvalidOperationException e)
            {
                var errorMessage = string.Format("Failed to deserialize object, error: {0}", e.Message);
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
                var settings = new XmlWriterSettings {OmitXmlDeclaration = true, Indent = true};

                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                using (var writer = XmlWriter.Create(location, settings))
                {
                    var xml = new XmlSerializer(typeof (TMyType));
                    xml.Serialize(writer, t, namespaces);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidateXml(string xml, string xsd, string targetNamespace, out string message)
        {
            var schemas = new XmlSchemaSet();
            schemas.Add(targetNamespace, xsd);

            var doc = XDocument.Load(xml);
            var msg = "";
            doc.Validate(schemas, (o, e) => { msg += e.Message + Environment.NewLine; });
            message = msg;
            return string.IsNullOrEmpty(message);
        }
    }
}