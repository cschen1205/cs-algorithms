using System.Collections.Generic;
using Algorithms.DataStructures.Graphs;
using Algorithms.Graphs.Search;
using DataStructures.Stack;

namespace Algorithms.Graphs.Cycles
{
    public class DirectedCycles
    {
        private bool[] marked;
        private bool[] onStack;
        private int[] edgeTo;
        private StackLinkedList<int> circle;

        public DirectedCycles(DiGraph G)
        {

            var V = G.V();
            marked = new bool[V];
            edgeTo = new int[V];
            onStack = new bool[V];

        }

        private void dfs(DiGraph G, int v)
        {
            marked[v] = true;
            onStack[v] = true;
            foreach (var w in G.adj(v))
            {
                if (!marked[w])
                {
                    edgeTo[w] = v;
                    dfs(G, w);
                } else if (onStack[w])
                {
                    if (circle == null)
                    {
                        return;
                    }
                    else
                    {
                        circle = new StackLinkedList<int>();
                        for (var x = w; x != v; x = edgeTo[x]) {
                            circle.Push(x);
                        }

                            circle.Push(v);
                        circle.Push(w);

                    }
                }
            }
            onStack[v] = false;
        }


        public bool HasCycle => circle != null;
        public IEnumerable<int> Cycle => circle;

    }
}