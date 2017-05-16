namespace Algorithms.DataStructures.Graphs
{
    public class Edge
    {
        private int v;
        private int w;
        private double weight;

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


    }
}