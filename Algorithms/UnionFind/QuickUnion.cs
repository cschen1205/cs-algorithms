using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSChen.Algorithms.UnionFind
{
    public class QuickUnion : IUnionFind
    {
        protected int[] mParentID = null;
        public QuickUnion(int n)
        {
            mParentID = new int[n];
            for (var i = 0; i < n; ++i)
            {
                mParentID[i] = i;
            }
        }

        public void Union(int i, int j)
        {
            var p = GetRoot(i);
            var q = GetRoot(j);
            mParentID[p] = q;
        }

        protected int GetRoot(int i)
        {
            while (mParentID[i] != i)
            {
                i = mParentID[i];
            }
            return i;
        }

        public bool IsConnected(int i, int j)
        {
            return GetRoot(i) == GetRoot(j);
        }
    }
}
