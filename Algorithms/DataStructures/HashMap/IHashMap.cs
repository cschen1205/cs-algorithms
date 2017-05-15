using System.Collections.Generic;

namespace Algorithms.DataStructures.HashMap
{
    public interface IHashMap<K, V>
    {
        V this[K key] { get; set; }
        bool ContainsKey(K key);
        int Count { get;  }
        bool IsEmpty { get; }
        void Delete(K key);
        IEnumerable<K> Keys { get; }
    }
}