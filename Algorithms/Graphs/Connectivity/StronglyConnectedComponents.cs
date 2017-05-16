using Algorithms.DataStructures.Graphs;
using Algorithms.Graphs.TopologicalSort;

namespace Algorithms.Graphs.Connectivity
{
    public class StronglyConnectedComponents
    {
        private bool[] marked;
        private int[] id;
        private int count;
        public StronglyConnectedComponents(DiGraph G)
        {
            count = 0;
            var V = G.V();
            marked = new bool[V];
            id = new int[V];

            var ts = new DepthFirstPostOrder(G.reverse());
            foreach (var v in ts.PostOrder())
            {
                if (!marked[v])
                {
                    dfs(G, v);
                    count++;
                }
            }
        }

        private void dfs(DiGraph G, int v)
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