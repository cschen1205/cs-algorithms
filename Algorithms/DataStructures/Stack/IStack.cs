using System;

namespace DataStructures.Stack
{
    public interface IStack<T>
    {
        T Pop();
        void Push(T item);
        int Count { get;  }
        bool IsEmpty { get;  }
    }
}