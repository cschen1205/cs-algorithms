using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.UnionFind
{
    public interface IUnionFind
    {
        void Union(int i, int j);
        bool IsConnected(int i, int j);
    }
}
