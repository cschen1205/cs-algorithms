using System.Collections.Generic;

namespace Algorithms.DataStructures.Graphs
{
    public class WeightedDiGraph
    {
        private int vertexCount;
        private List<Edge>[] adjList;

        public WeightedDiGraph(int V)
        {
            vertexCount = V;
            adjList = new List<Edge>[V];
            for (var v = 0; v < V; ++v)
            {
                adjList[v] =new List<Edge>();
            }
        }

        public void addEdge(Edge e)
        {
            var v = e.from();

            adjList[v].Add(e);
        }

        public List<Edge> adj(int v)
        {
            return adjList[v];
        }

        public int V()
        {
            return vertexCount;
        }

        public List<Edge> edges()
        {
            var result = new List<Edge>();
            for (var v = 0; v < vertexCount; ++v)
            {
                result.AddRange(adjList[v]);
            }
            return result;
        }

        public DiGraph ToDiGraph()
        {
            DiGraph g = new DiGraph(vertexCount);

            foreach(var e in edges())
            {
                g.addEdge(e.from(), e.to());
            }

            return g;
        }
    }
}