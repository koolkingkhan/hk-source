using System;
using System.Collections.Generic;
using System.Xml;
using hk.QuickestRouteFinder.Interfaces;

namespace hk.QuickestRouteFinder
{
    public class RouteFinder : IRouteFinder
    {
        private readonly RouteManagement<Routes> _routeManagement;

        public RouteFinder(XmlDocument document)
        {
            if (null == document)
                throw new ArgumentNullException("document", "Paramater cannot be null");

            _routeManagement = new RouteManagement<Routes>(document);
        }

        public IEnumerable<string> Stations
        {
            get
            {
                return null != _routeManagement ? _routeManagement.Stations : null;
            }
        }

        public int ShortestTime(string from, string to)
        {
            return null != _routeManagement ? _routeManagement.ShortestTime(from, to) : -1;
        }
    }
}