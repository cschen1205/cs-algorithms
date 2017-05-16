using System.Collections.Generic;
using Algorithms.DataStructures.Graphs;
using Algorithms.DataStructures.Queue;

namespace Algorithms.Graphs.MST
{
    public class LazyPrim
    {
        private bool[] marked;
        private List<Edge> mst;
        private MinPQ<Edge> pq;

        public LazyPrim(WeightedGraph G)
        {
            var V = G.V();
            marked = new bool[V];
            pq = new MinPQ<Edge>();

            var s = 0;
            foreach (var e in G.adj(s))
            {
                pq.Enqueue(e);
            }

            mst = new List<Edge>();

            while (!pq.IsEmpty && mst.Count < V - 1)
            {
                var e = pq.DelMin();
                var v = e.either();
                var w = e.other(v);

                if (marked[v] && marked[w]) continue;

                mst.Add(e);

                if(!marked[v]) visit(G, v);
                if (!marked[w]) visit(G, w);
            }
        }

        private void visit(WeightedGraph G, int v)
        {
            marked[v] = true;
            foreach (var e in G.adj(v))
            {
                var w = e.other(v);
                if (!marked[w])
                {
                    pq.Enqueue(e);
                }
            }
        }

        public List<Edge> MST => mst;
    }
}