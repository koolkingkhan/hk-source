using System;
using System.Collections.Generic;
using System.Diagnostics;
using QuickGraph;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.ShortestPath;

namespace hk.QuickestRouteFinder
{
    internal class RouteCalculator
    {
        private readonly AdjacencyGraph<string, Edge<string>> _graph;
        private readonly Dictionary<Edge<string>, int> _weight;
        private DijkstraShortestPathAlgorithm<string, Edge<string>> _algorithm;
        private VertexPredecessorRecorderObserver<string, Edge<string>> _predecessorObserver;

        public RouteCalculator()
        {
            _graph = new AdjacencyGraph<string, Edge<string>>(true);
            _weight = new Dictionary<Edge<string>, int>();
        }

        internal IEnumerable<string> Stations
        {
            get { return _graph.Vertices; }
        }

        internal void AddRoutes(IEnumerable<RouteMetadata> routes)
        {
            Debug.Assert(null != routes, "Routes is null");

            foreach (var route in routes)
            {
                var from = route.From.ToLowerInvariant();
                var to = route.To.ToLowerInvariant();

                if (!_graph.ContainsVertex(from))
                {
                    _graph.AddVertex(from);
                }

                if (!_graph.ContainsVertex(to))
                {
                    _graph.AddVertex(to);
                }

                var edge = new Edge<string>(from, to);

                if (!_graph.ContainsEdge(edge))
                {
                    _graph.AddEdge(edge);
                    _weight.Add(edge, route.Time);
                }
            }
        }

        internal int CalculateShortestRoute(string from, string to)
        {
            from = from.ToLowerInvariant();
            to = to.ToLowerInvariant();

            if (!(_graph.ContainsVertex(from) && _graph.ContainsVertex(to)))
            {
                return -1;
            }

            if (null == _algorithm)
            {
                _algorithm = new DijkstraShortestPathAlgorithm<string, Edge<string>>(_graph, e => _weight[e]);
            }

            if (null == _predecessorObserver)
            {
                _predecessorObserver = new VertexPredecessorRecorderObserver<string, Edge<string>>();
            }

            using (_predecessorObserver.Attach(_algorithm))
            {
                // Run the algorithm with "from" set to be the source
                _algorithm.Compute(from);

                return Convert.ToInt32(_algorithm.Distances[to]);
            }
        }
    }
}