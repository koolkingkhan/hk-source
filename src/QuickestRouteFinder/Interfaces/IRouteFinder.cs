using System.Collections.Generic;

namespace hk.QuickestRouteFinder.Interfaces
{
    public interface IRouteFinder
    {
        IEnumerable<string> Stations { get; }

        int ShortestTime(string from, string to);
    }
}
