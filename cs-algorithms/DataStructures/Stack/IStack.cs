using System;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public interface IStack<T> : IEnumerable<T>
    {
        T Pop();
        void Push(T item);
        int Count { get;  }
        bool IsEmpty { get;  }
    }
}