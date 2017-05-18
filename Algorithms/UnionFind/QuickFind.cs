using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.UnionFind
{
    public class QuickFind : IUnionFind
    {
        protected int[] mID;
        public QuickFind(int n)
        {
            mID = new int[n];
            for (var i = 0; i < n; ++i)
            {
                mID[i] = i;
            }
        }

        public void Union(int i, int j)
        {
            var p = mID[i];
            var q = mID[j];
            if (p == q) return;
            for (var k = 0; k < mID.Length; ++k)
            {
                if (mID[k] == q)
                {
                    mID[k] = p;
                }
            }
        }

        public bool IsConnected(int i, int j)
        {
            return mID[i] == mID[j];
        }
    }
}
