﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using hk.Common.Utilities;
using hk.QuickestRouteFinder.Interfaces;

namespace hk.QuickestRouteFinder
{
    internal class RouteManagement<T> where T : IRoutes, new()
    {
        private readonly RouteCalculator _routeCalculator;
        private T _routes;

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
            get { return null != _routeCalculator ? _routeCalculator.Stations : null; }
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

            using (var stream = new MemoryStream())
            {
                document.Save(stream);
                stream.Flush();
                stream.Position = 0;
                return HelperMethods.TryDeserialize(stream, out _routes) ? _routes : default(T);
            }
        }


        private bool TrySerialize<TMyType>()
        {
            if (null == _routes)
            {
                return false;
            }

            try
            {
                var saveLocation = Path.Combine(Path.GetPathRoot(Environment.CurrentDirectory), "test.xml");
                using (var writer = new StreamWriter(saveLocation, false))
                {
                    var xml = new XmlSerializer(typeof (TMyType));
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