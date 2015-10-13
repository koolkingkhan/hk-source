using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;
using Ubs.Collateral.Sre.Common.Rules.Settings;

namespace sre.ui.Settings
{
    public class RulesCollection
    {
        private const string SettingsPath = @"C:\ubs\dev\Work\SOURCE\DroolsPoc\IntelliJDrools\src\main\resources\settings.xml";
        private DroolsMetadata _data;

        private readonly List<Parameter> _rules = new List<Parameter>();

        public List<Parameter> RuleParameterCollection
        {
            get
            {
                if (_rules.Count == 0)
                {
                    using (Stream stream = new FileStream(SettingsPath, FileMode.Open))
                    {
                        TryDeserialize(stream, out _data);

                        var parameters = _data.Items.FirstOrDefault(item => item is Parameters) as Parameters;
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters.ParameterCollection)
                            {
                                _rules.Add(parameter);
                            }
                        }
                    }
                }
                return _rules;
            }
        }

        public void Update(bool emergencySwitch)
        {
            MessageBox.Show(TrySerialize<DroolsMetadata>(emergencySwitch) ? "Updated settings" : "Failed to update settings");
        }

        private bool TrySerialize<TMyType>(bool emergencySwitch)
        {
            if (null == _rules)
            {
                return false;
            }

            ((EmergencySwitch) _data.Items[0]).Value = emergencySwitch;
            ((Parameters)_data.Items[1]).ParameterCollection = _rules;

            try
            {
                using (StreamWriter writer = new StreamWriter(SettingsPath))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");

                    XmlSerializer serializer = new XmlSerializer(typeof(TMyType));
                    serializer.Serialize(writer, _data, ns);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool TryDeserialize<TMyType>(Stream stream, out TMyType t)
        {
            t = default(TMyType);

            if (null == stream)
            {
                return false;
            }

            bool success = false;

            using (StreamReader reader = new StreamReader(stream))
            {
                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(TMyType));
                    t = (TMyType)deserializer.Deserialize(reader);
                    success = true;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(string.Format("Failed to deserialize columns, error: {0}", e.Message));
                }
            }

            return success;
        }
    }
}
