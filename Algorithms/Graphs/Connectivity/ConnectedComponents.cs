using System.Threading;
using Algorithms.DataStructures.Graphs;

namespace Algorithms.Graphs.Connectivity
{
    public class ConnectedComponents
    {
        private bool[] marked;
        private int[] id;
        private int count = 0;

        public ConnectedComponents(Graph G)
        {
            count = 0;
            var V = G.V();
            marked = new bool[V];
            id = new int[V];

            for (var v = 0; v < V; ++v)
            {
                id[v] = -1;
            }

            for (var v = 0; v < V; ++v)
            {
                if (!marked[v])
                {
                    dfs(G, v);
                }
            }
        }

        private void dfs(Graph G, int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach (var w in G.adj(v))
            {
                if (!marked[w])
                {
                    dfs(G, w);
                }
            }
        }

        public int componentId(int v)
        {
            return id[v];
        }

        public int Count => count;
    }
}