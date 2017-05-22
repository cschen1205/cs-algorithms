using System.Collections.Generic;

namespace Algorithms.DataStructures.Graphs
{
    public class WeightedGraph
    {
        private int vertexCount;
        private List<Edge>[] adjList;

        public WeightedGraph(int V)
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
            var v = e.either();
            var w = e.other(v);

            adjList[v].Add(e);
            adjList[w].Add(e);
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
    }
}