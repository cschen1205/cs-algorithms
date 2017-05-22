using System;

namespace Algorithms.DataStructures.Graphs
{
    public class Edge : IComparable<Edge>
    {
        private int v;
        private int w;
        private double weight;
        private IComparable<Edge> _comparableImplementation;

        public Edge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;

        }

        public int either()
        {
            return v;
        }

        public int other(int v)
        {
            return this.v == v ? w : this.v;
        }

        public int from()
        {
            return v;
        }

        public int to()
        {
            return w;
        }

        public double Weight => weight;


        public int CompareTo(Edge that)
        {
            return weight.CompareTo(that.Weight);
        }

        public override String ToString()
        {
            return v + " =(" + weight + ")=> " + w;
        }
    }
}