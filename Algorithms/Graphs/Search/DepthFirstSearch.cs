using System;
using System.Collections.Generic;
using Algorithms.DataStructures.Graphs;
using DataStructures.Stack;

namespace Algorithms.Graphs.Search
{
    public class DepthFirstSearch
    {
        private bool[] marked;
        private int[] edgeTo;
        private int s;
        private int V;
        public DepthFirstSearch(Graph G, int s)
        {
            this.s = s;
            this.V = G.V();

            marked = new bool[V];
            edgeTo = new int[V];

            dfs(G, s);

        }

        private void dfs(Graph G, int v)
        {
            marked[v] = true;
            foreach (var w in G.adj(v))
            {
                if (marked[w]) continue;
                edgeTo[w] = v;
                dfs(G, w);
            }
        }

        public bool CanReach(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> Path(int v)
        {
            if (!marked[v]) return new List<int>();

            var path = new StackLinkedList<int>();

            for (var x = v; x != s; x = edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(s);
            return path;
        }
    }
}