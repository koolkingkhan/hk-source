using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using hk.QuickestRouteFinder.Interfaces;

namespace hk.QuickestRouteFinder
{
    internal class RouteManagement<T> where T : IRoutes, new()
    {
        private T _routes;
        private readonly RouteCalculator _routeCalculator;

        public RouteManagement(XmlDocument document)
        {
            if (null == document)
                throw new ArgumentNullException("document", "Parameter cannot be null");

            if (null == _routes)
            {
                LoadRoutes(document);
                Debug.Assert(null != _routes, "Could not load routes!");
            }

            if (null == _routeCalculator)
            {
                _routeCalculator = new RouteCalculator();
                _routeCalculator.AddRoutes(_routes.RoutesAndTravelTimes);
            }
        }

        internal IEnumerable<string> Stations
        {
            get
            {
                return null != _routeCalculator ? _routeCalculator.Stations : null;
            }
        }

        internal int ShortestTime(string from, string to)
        {
            return null != _routeCalculator ? _routeCalculator.CalculateShortestRoute(from, to) : -1;
        }

        internal void SaveNewRoutes()
        {
            if (TrySerialize<T>())
            {
                Debug.WriteLine("Successfully updated column preferences!");
            }
        }

        internal T LoadRoutes(XmlDocument document)
        {
            if (null != _routes)
            {
                return _routes;
            }

            using (XmlTextReader stream = new XmlTextReader(new StringReader(document.InnerXml)))
            {
                return TryDeserialize(stream, out _routes) ? _routes : default(T);
            }
        }

        private bool TryDeserialize<TMyType>(XmlTextReader stream, out TMyType t)
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

        private bool TrySerialize<TMyType>()
        {
            if (null == _routes)
            {
                return false;
            }

            try
            {
                string saveLocation = Path.Combine(Path.GetPathRoot(Environment.CurrentDirectory), "test.xml");
                using (StreamWriter writer = new StreamWriter(saveLocation, false))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(TMyType));
                    xml.Serialize(writer, _routes);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
