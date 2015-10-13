using System.Collections.Generic;
using System.Xml.Serialization;

namespace sre.model
{
    public interface INegotiations
    {        
        List<Negotiation> Items { get; set; }
    }

    [XmlRoot(ElementName = "negotiations")]
    public class Negotiations : INegotiations
    {
        [XmlElement(ElementName = "negotiation")]
        public List<Negotiation> Items { get; set; }
    }
}
