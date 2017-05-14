using System;

namespace Algorithms.DataStructures.TreeMap
{
    public interface ITreeMap<K, V> where K : IComparable<K>
    {
        V this[K key] { get; set; }
        int Count { get;  }
        bool IsEmpty { get; }
        bool ContainsKey(K key);
    }
}