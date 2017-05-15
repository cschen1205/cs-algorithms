using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.DataStructures.Graphs;
using DataStructures.Stack;

namespace Algorithms.Graphs.TopologicalSort
{
    public class DepthFirstPostOrder
    {
        private bool[] marked;
        private StackLinkedList<int> reversePostOrder;

        public DepthFirstPostOrder(DiGraph G)
        {
            var V = G.V();

            marked = new bool[V];
            reversePostOrder = new StackLinkedList<int>();
            for (var v = 0; v < V; ++v)
            {
                if (marked[v]) continue;
                dfs(G, v);
            }
        }

        private void dfs(DiGraph G, int v)
        {
            marked[v] = true;
            foreach (var w in G.adj(v))
            {
                if (marked[w]) continue;
                dfs(G, w);
            }
            reversePostOrder.Push(v);
        }

        public IEnumerable<int> PostOrder()
        {
            return reversePostOrder;
        }

        public String PostOrderToString()
        {
            StringBuilder sb = new StringBuilder();
            var first = true;
            foreach (var x in PostOrder())
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.Append(" => ");
                }
                sb.Append(x);
            }
            return sb.ToString();
        }
    }
}