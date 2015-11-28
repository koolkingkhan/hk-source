using System.Collections.Generic;

namespace hk.QuickestRouteFinder.Interfaces
{
    internal interface IRoutes
    {
        List<RouteMetadata> RoutesAndTravelTimes { get; set; }
    }
}