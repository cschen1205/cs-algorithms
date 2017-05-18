using System;
using Algorithms.UnionFind;
using Xunit;

namespace AlgorithmsUnitTest.UnionFind
{
    public class PercolationUnitTest
    {
        protected Random mRandom = new Random();

        [Fact]
        public void RunPercolation()
        {
            var p = new Percolation(100, 100);
            const int iterations = 10;
            var percolationThreshold = p.RunMonteCarlo(mRandom, iterations);
            Console.WriteLine("Percolation Threshold: {0}", percolationThreshold);
        }
    }
}