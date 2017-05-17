using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.DataStructures.Graphs;
using Algorithms.DataStructures.Queue;

namespace Algorithms.Graphs.MST
{
    public class EagerPrim
    {
        private IndexMinPQ<Edge> pq;
        private List<Edge> path;
        private bool[] marked;

        public EagerPrim(WeightedGraph G)
        {
            int V = G.V();
            pq = new IndexMinPQ<Edge>(V);

            marked = new bool[V];

            Visit(G, 0);

            path = new List<Edge>();

            while (!pq.IsEmpty)
            {
                var e = pq.MinKey();
                var v = pq.DelMin();
                path.Add(e);
                if(!marked[v]) Visit(G, v);
            }
        }

        private void Visit(WeightedGraph G, int v)
        {
            marked[v] = true;
            foreach (var e in G.adj(v))
            {
                int w = e.other(v);
                if (!marked[w])
                {
                    if (pq.Contains(w))
                    {
                        pq.Insert(w, e);
                    }
                    else
                    {
                        pq.DecreaseKey(w, e);
                    }
                }
            }
        }

        public List<Edge> MST => path;
    }
}