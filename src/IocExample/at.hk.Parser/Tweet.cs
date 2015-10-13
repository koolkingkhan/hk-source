using System;
using System.Xml.Serialization;

namespace at.hk.Parser
{
    [Serializable]
    public class Tweet : ITweet
    {
        #region Implementation of ITweet

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Date { get; set; }

        [XmlElement]
        public string Message { get; set; }

        #endregion
    }
}