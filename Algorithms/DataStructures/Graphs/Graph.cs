using System.Collections.Generic;

namespace Algorithms.DataStructures.Graphs
{
    public class Graph
    {
        private int vertexCount;
        private List<int>[] adjList;
        public Graph(int V)
        {
            this.vertexCount = V;
            adjList = new List<int>[V];
        }

        public int V()
        {
            return vertexCount;
        }

        public List<int> adj(int v)
        {
            return adjList[v];
        }


    }
}