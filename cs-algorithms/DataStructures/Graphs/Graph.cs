using System.Collections.Generic;

namespace Algorithms.DataStructures.Graphs
{
    public class Graph
    {
        private int vertexCount;
        private List<int>[] adjList;
        public Graph(int V)
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

        public void addEdge(int w, int v)
        {
            adjList[v].Add(w);
            adjList[w].Add(v);
        }


    }
}