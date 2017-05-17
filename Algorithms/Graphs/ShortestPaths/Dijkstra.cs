using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Xml;
using Algorithms.DataStructures.Graphs;
using Algorithms.DataStructures.Queue;
using DataStructures.Stack;

namespace Algorithms.Graphs.ShortestPaths
{
    public class Dijkstra
    {
        private int s;
        private bool[] marked;
        private Edge[] edgeTo;
        private double[] cost;
        private IndexMinPQ<Double> pq;

        public Dijkstra(WeightedDiGraph G, int s)
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

            pq = new IndexMinPQ<Double>(V);


            pq.Insert(s, 0);

            while (!pq.IsEmpty)
            {
                var v = pq.DelMin();
                marked[v] = true;
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
                if (!pq.Contains(w))
                {
                    pq.Insert(w, cost[w]);
                }
                else
                {
                    pq.DecreaseKey(w, cost[w]);
                }
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