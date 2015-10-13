using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Ubs.Collateral.Sre.Common.Rules.Settings
{
    [Serializable]
    [XmlRoot("settings")]
    public class DroolsMetadata
    {
        [XmlElement("emergencySwitch", typeof(EmergencySwitch)), XmlElement("parameters", typeof(Parameters))]
        public List<object> Items { get; set; }
    }

    [Serializable]
    public class EmergencySwitch
    {
        [XmlAttribute(AttributeName = "value")]
        public bool Value { get; set; }
    }

    [Serializable]
    public class Parameters
    {
        [XmlElement("parameter")]
        public List<Parameter> ParameterCollection { get; set; }
    }

    [Serializable]
    public class Parameter
    {
        [XmlElement("argument", IsNullable = true)]
        public List<ArgumentMetadata> Arguments { get; set; }

        [XmlAttribute(AttributeName = "rule")]
        public string RuleName { get; set; }
    }

    [Serializable]
    public class ArgumentMetadata
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "delimiter")]
        public string Delimiter { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

}
