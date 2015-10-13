using System.Collections.Generic;
using System.Xml.Serialization;
using hk.QuickestRouteFinder.Interfaces;

namespace hk.QuickestRouteFinder
{
    public class RouteMetadata
    {
        [XmlAttribute(AttributeName = "From", DataType = "string")]
        public string From { get; set; }

        [XmlAttribute(AttributeName = "To", DataType = "string")]
        public string To { get; set; }

        [XmlAttribute(AttributeName = "Time", DataType = "int")]
        public int Time { get; set; }
    }

    public class Routes : IRoutes
    {
        [XmlArray("RoutesAndTravelTimes")]
        [XmlArrayItem(Type = typeof(RouteMetadata), IsNullable = false)]
        public List<RouteMetadata> RoutesAndTravelTimes { get; set; }
    }
}
