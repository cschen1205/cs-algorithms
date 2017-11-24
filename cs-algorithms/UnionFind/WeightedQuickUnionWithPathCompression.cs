using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.UnionFind
{
    public class WeightedQuickUnionWithPathCompression : IUnionFind
    {
        protected int[] mParent = null;
        protected int[] mSize = null;
        public WeightedQuickUnionWithPathCompression(int n)
        {
            mParent = new int[n];
            mSize = new int[n];
            for (int i = 0; i < n; ++i)
            {
                mParent[i] = i;
                mSize[i] = 1;
            }
        }

        public int GetSize(int i)
        {
            int r = GetRoot(i);
            return mSize[r];
        }

        protected int GetRoot(int i)
        {
            while (mParent[i] != i)
            {
                mParent[i] = mParent[mParent[i]];
                i = mParent[i];
            }
            return i;
        }

        public void Union(int p, int q)
        {
            int i = GetRoot(p);
            int j = GetRoot(q);
            if (i!=j)
            {
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
        }

        public bool IsConnected(int i, int j)
        {
            return GetRoot(i) == GetRoot(j);
        }
    }
}
