using System.Collections.Generic;
using Algorithms.DataStructures.Graphs;
using Algorithms.DataStructures.Queue;
using DataStructures.Stack;

namespace Algorithms.Graphs.Search
{
    public class BreadthFirstSearch
    {
        private bool[] marked;
        private int[] edgeTo;
        private int s;

        public BreadthFirstSearch(Graph G, int s)
        {
            var V = G.V();
            this.s = s;

            var queue = new QueueLinkedList<int>();
            queue.Enqueue(s);

            marked = new bool[V];
            edgeTo = new int[V];

            marked[s] = true;

            while (!queue.IsEmpty)
            {
                var v = queue.Dequeue();

                foreach (var w in G.adj(v))
                {
                    if (marked[w]) continue;
                    edgeTo[w] = v;
                    marked[w] = true;
                    queue.Enqueue(w);
                }
            }
        }

        public bool CanReach(int v){
            return marked[v];
        }

        public IEnumerable<int> Path(int v)
        {
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