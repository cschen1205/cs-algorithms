using System;
using System.Collections.Generic;
using Algorithms.DataStructures.Graphs;
using DataStructures.Stack;

namespace Algorithms.Graphs.ShortestPaths
{
    public class BellmanFulkerson
    {
        private double[] cost;
        private Edge[] edgeTo;
        private int s;
        private bool negativeCycles;

        public BellmanFulkerson(WeightedDiGraph G, int s)
        {
            this.s = s;
            var V = G.V();
            cost = new double[V];
            for (var v = 0; v < V; ++v)
            {
                cost[v] = Double.MaxValue;
            }

            edgeTo = new Edge[V];
            cost[s] = 0;

            for (var j = 0; j < V; ++j)
            {
                for (var v = 0; v < V; ++v)
                {
                    foreach (var e in G.adj(v))
                    {
                        Relax(G, e);
                    }
                }
            }

            negativeCycles = false;
            for (var v = 0; v < V; ++v)
            {
                foreach (var e in G.adj(v))
                {
                    if (Relax(G, e))
                    {
                        negativeCycles = true;
                    }
                }
            }
        }

        private bool Relax(WeightedDiGraph G, Edge e)
        {
            var v = e.from();
            var w = e.to();
            if (cost[w] > cost[v] + e.Weight)
            {
                cost[w] = cost[v] + e.Weight;
                edgeTo[w] = e;

                return true;
            }
            return false;
        }

        public bool HasPathTo(int v)
        {
            return cost[v] < Double.MaxValue;
        }

        public bool HashNegativeCycles()
        {
            return negativeCycles;
        }

        public IEnumerable<Edge> PathTo(int v)
        {
            var path = new StackLinkedList<Edge>();
            for (var x = v; x != this.s; x = edgeTo[x].other(x))
            {
                path.Push(edgeTo[x]);
            }

            return path;
        }
    }
}