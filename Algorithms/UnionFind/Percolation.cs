using System;

namespace Algorithms.UnionFind
{
    public class Percolation
    {
        private readonly int mWidth;
        private readonly int mHeight;
        private readonly int[] top;
        private readonly int[] bottom;

        public Percolation(int width, int height)
        {
            mWidth = width;
            mHeight = height;

            top = new int[mWidth];
            bottom = new int[mWidth];

            for (var i = 0; i < mWidth; ++i)
            {
                top[i] = i;
            }

            for (var i = 0; i < mWidth; ++i)
            {
                bottom[i] = (mHeight - 1) * mWidth + i;
            }
        }

        public double RunMonteCarlo(Random rand, int iterations)
        {
            double percolationThreshold = 0;
            for (var i = 0; i < iterations; ++i)
            {
                percolationThreshold += ComputePercolationThreshold(rand);
            }
            return percolationThreshold / iterations;
        }

        public double ComputePercolationThreshold(Random rand)
        {
            var n = mWidth * mHeight;

            var uf = new WeightedQuickUnionWithPathCompression(n);

            var connected_top_site = -1;
            var connected_bottom_site = -1;
            while (!IsPercolated(uf, out connected_top_site, out connected_bottom_site))
            {
                var i = rand.Next(n);
                var j = i;
                while (i == j || uf.IsConnected(i, j))
                {
                    j = rand.Next(n);
                }
                uf.Union(i, j);
            }

            var componentSize = uf.GetSize(connected_top_site);

            var percolationThreshold = (double)componentSize / n;

            return percolationThreshold;
        }


        private bool IsPercolated(IUnionFind uf, out int selected_top_cell, out int selected_bottom_cell)
        {
            selected_top_cell = -1;
            selected_bottom_cell = -1;

            foreach (var top_cell in top)
            {
                foreach (var bottom_cell in bottom)
                {
                    if (!uf.IsConnected(top_cell, bottom_cell)) continue;
                    selected_top_cell = top_cell;
                    selected_bottom_cell = bottom_cell;
                    return true;
                }
            }
            return false;
        }
    }
}