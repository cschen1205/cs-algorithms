using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSChen.Algorithms.UnionFind
{
    public class QuickFind : IUnionFind
    {
        protected int[] mID;
        public QuickFind(int n)
        {
            mID = new int[n];
            for (int i = 0; i < n; ++i)
            {
                mID[i] = i;
            }
        }

        public void Union(int i, int j)
        {
            mID[i] = mID[j];
        }

        public bool IsConnected(int i, int j)
        {
            return mID[i] == mID[j];
        }
    }
}
