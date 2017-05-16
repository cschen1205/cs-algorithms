using System.Collections.Generic;

namespace Algorithms.DataStructures.Graphs
{
    public class DiGraph
    {
        private int vertexCount;
        private List<int>[] adjList;
        public DiGraph(int V)
        {
            vertexCount = V;
            adjList = new List<int>[V];
            for (var v = 0; v < V; ++v)
            {
                adjList[v] = new List<int>();
            }
        }

        public int V()
        {
            return vertexCount;
        }

        public List<int> adj(int v)
        {
            return adjList[v];
        }

        public void addEdge(int v, int w)
        {
            adjList[v].Add(w);
        }

        public DiGraph reverse()
        {
            var g = new DiGraph(vertexCount);
            for (var v = 0; v < vertexCount; ++v)
            {
                foreach (var w in adjList[v])
                {
                    g.addEdge(w, v);
                }
            }

            return g;
        }
    }
}