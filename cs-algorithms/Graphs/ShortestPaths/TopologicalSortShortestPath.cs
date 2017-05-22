using System;
using System.Collections.Generic;
using Algorithms.DataStructures.Graphs;
using Algorithms.DataStructures.Queue;
using Algorithms.Graphs.TopologicalSort;
using DataStructures.Stack;

namespace Algorithms.Graphs.ShortestPaths
{
    public class TopologicalSortShortestPath
    {
        private int s;
        private bool[] marked;
        private Edge[] edgeTo;
        private double[] cost;
        public TopologicalSortShortestPath(WeightedDiGraph G, int s)
        {
            this.s = s;
            int V = G.V();
            marked = new bool[V];
            edgeTo = new Edge[V];
            cost = new double[V];

            for (var i = 0; i < V; ++i)
            {
                cost[i] = Double.MaxValue;
            }

            cost[s] = 0;

            DepthFirstPostOrder dfo = new DepthFirstPostOrder(G.ToDiGraph());

            foreach (var v in dfo.PostOrder())
            {
                foreach (var e in G.adj(v))
                {
                    Relax(G, e);
                }
            }

        }

        private void Relax(WeightedDiGraph G, Edge e)
        {
            int v = e.from();
            int w = e.to();
            if (cost[w] > cost[v] + e.Weight)
            {
                cost[w] = cost[v] + e.Weight;
                edgeTo[w] = e;
                marked[w] = true;
            }
        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<Edge> PathTo(int v)
        {
            var path = new StackLinkedList<Edge>();
            for (var x = v; x != s; x = edgeTo[x].from())
            {
                path.Push(edgeTo[x]);
            }
            return path;
        }
    }
}