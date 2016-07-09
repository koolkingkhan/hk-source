using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using hk.Common.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

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

            var totalSumOfNumbers = lastNumber * (lastNumber + 1) / 2;

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
                var deserializer = new XmlSerializer(typeof(TMyType));
                t = (TMyType)deserializer.Deserialize(stream);
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
                var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };

                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                using (var writer = XmlWriter.Create(location, settings))
                {
                    var xml = new XmlSerializer(typeof(TMyType));
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

        public static void WriteToJsonFile<T>(T obj, string filePath = @"C:\Users\Hussain\Desktop\SOURCE\hk-source\sample.json", bool append = false) where T : MessagingRequest, new()
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                });

                using (var writer = new StreamWriter(filePath, append))
                {
                    writer.Write(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool IsValid(string json, string schemaFile, out IList<string> errorList)
        {
            JObject jObject = LoadJson(json);
            jObject.IsValid(LoadSchema(schemaFile), out errorList);

            return errorList != null && errorList.Count == 0;
        }

        public static JSchema AutomaticallyGeneratedSchema<T>(T obj)
        {
            JSchemaGenerator jsonSchemaGenerator = new JSchemaGenerator();
            JSchema schema = jsonSchemaGenerator.Generate(typeof(T));

            var str = schema.ToString();

            return schema;
        }

        public static JObject LoadJson(string file)
        {
            using (StreamReader streamReader = File.OpenText(file))
            {
                using (JsonTextReader reader = new JsonTextReader(streamReader))
                {
                    return JObject.Load(reader);
                }
            }
        }

        public static JSchema LoadSchema(string schemaFile)
        {
            using (StreamReader file = File.OpenText(schemaFile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    return JSchema.Load(reader);
                }
            }
        }
    }
}