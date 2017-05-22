using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.UnionFind
{
    public class WeightedQuickUnion : IUnionFind
    {
        protected int[] mParent = null;
        protected int[] mSize = null;
        public WeightedQuickUnion(int n)
        {
            mParent = new int[n];
            mSize = new int[n];
            for (var i = 0; i < n; ++i)
            {
                mParent[i] = i;
                mSize[i] = 1;
            }
        }

        protected int GetRoot(int i)
        {
            while (mParent[i] != i)
            {
                i = mParent[i];
            }
            return i;
        }

        public void Union(int p, int q)
        {
            var i = GetRoot(p);
            var j = GetRoot(q);
            if (mSize[i] < mSize[j])
            {
                mParent[i] = j;
                mSize[j] += mSize[i];
            }
            else
            {
                mParent[j] = i;
                mSize[i] += mSize[j];
            }
        }

        public bool IsConnected(int i, int j)
        {
            return GetRoot(i) == GetRoot(j);
        }
    }
}
