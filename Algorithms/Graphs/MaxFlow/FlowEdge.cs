using System;

namespace Algorithms.Graphs.MaxFlow
{
    public class FlowEdge
    {
        private int v;
        private int w;
        private double capacity;
        private double flow;

        public FlowEdge(int v, int w, double capacity)
        {
            this.v = v;
            this.w = w;
            this.capacity = capacity;
        }

        public int from()
        {
            return v;
        }

        public int to()
        {
            return w;
        }

        public int either()
        {
            return v;
        }

        public int other(int x)
        {
            return x == v ? w : v;
        }

        public double residualCapacityTo(int x)
        {
            if (x == v) return flow;
            if (x == w) return capacity - flow;
            throw new NotImplementedException();
        }

        public void addResidualFlowTo(int x, double delta)
        {
            if (x == v) flow -= delta;
            else if (x == w) flow += delta;
        }
    }
}