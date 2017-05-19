using System.Collections.Generic;

namespace Algorithms.Graphs.MaxFlow
{
    public class FlowNetwork
    {
        private int vertexCount;
        private List<FlowEdge>[] adjList;

        public FlowNetwork(int V)
        {
            vertexCount = V;
            adjList = new List<FlowEdge>[V];
            for (var v = 0; v < V; v++)
            {
                adjList[v] = new List<FlowEdge>();
            }
        }

        public void addEdge(FlowEdge e)
        {
            var v = e.from();
            var w = e.to();
            adjList[v].Add(e);
            adjList[w].Add(e);
        }

        public List<FlowEdge> adj(int v)
        {
            return adjList[v];
        }

        public int V()
        {
            return vertexCount;
        }

    }
}