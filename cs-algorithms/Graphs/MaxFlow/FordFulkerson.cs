using System;
using Algorithms.DataStructures.Queue;

namespace Algorithms.Graphs.MaxFlow
{
    public class FordFulkerson
    {
        private int s;
        private int t;
        private FlowEdge[] edgeTo;
        private bool[] marked;
        private double value;

        public FordFulkerson(FlowNetwork G, int s, int t)
        {


            this.s = s;
            this.t = t;
            value = 0;

            while (HasAugmentedPath(G))
            {
                var bottle = double.MaxValue;
                for (var x = t; x != s; x = edgeTo[x].other(x))
                {
                    bottle = Math.Min(bottle, edgeTo[x].residualCapacityTo(x));
                }

                for (var x = t; x != s; x = edgeTo[x].other(x))
                {
                    edgeTo[x].addResidualFlowTo(x, bottle);
                }

                value += bottle;

            }
        }

        private bool HasAugmentedPath(FlowNetwork G)
        {
            var V = G.V();
            edgeTo = new FlowEdge[V];
            marked = new bool[V];
            var queue =new QueueLinkedList<int>();
            queue.Enqueue(s);

            while (!queue.IsEmpty)
            {
                var x = queue.Dequeue();
                marked[x] = true;
                foreach (var e in G.adj(x))
                {
                    var w = e.other(x);

                    if (!marked[w] && e.residualCapacityTo(w) > 0)
                    {
                        queue.Enqueue(w);
                        edgeTo[w] = e;

                        if (w == t)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public double Value => value;
    }
}