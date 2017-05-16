using System.Collections.Generic;
using Algorithms.DataStructures.Graphs;
using Algorithms.DataStructures.Queue;
using CSChen.Algorithms.UnionFind;

namespace Algorithms.Graphs.MST
{
    public class Kruskal
    {
        private List<Edge> mst;
        public Kruskal(WeightedGraph G)
        {
            var V = G.V();
            var uf =new QuickUnion(V);

            var pq =new MinPQ<Edge>();

            mst =new List<Edge>();
            foreach(Edge e in G.edges())
            {
                pq.Enqueue(e);
            }

            while (!pq.IsEmpty && mst.Count < V - 1)
            {
                var e = pq.DelMin();
                var v = e.either();
                var w = e.other(v);

                if (!uf.IsConnected(v, w))
                {
                    uf.Union(v, w);
                    mst.Add(e);
                }
            }


        }

        public List<Edge> MST => mst;
    }
}