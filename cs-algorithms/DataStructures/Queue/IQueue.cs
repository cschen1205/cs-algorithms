using System.Collections.Generic;

namespace Algorithms.DataStructures.Queue
{
    public interface IQueue<T> : IEnumerable<T>
    {
        T Dequeue();
        void Enqueue(T item);
        int Count { get;  }
        bool IsEmpty { get; }
    }
}