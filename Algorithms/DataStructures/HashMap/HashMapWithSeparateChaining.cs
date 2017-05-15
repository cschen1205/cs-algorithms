using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures.HashMap
{
    public class Node<K, V>
    {
        internal K key;
        internal V value;
        internal Node<K, V> next;
    }

    public class HashMapWithSeparateChaining<K, V> : IHashMap<K, V>
    {
        private const int M = 97;
        private Node<K, V>[] s;
        private int N = 0;

        public HashMapWithSeparateChaining()
        {
            s = new Node<K, V>[M];

        }

        public V this[K key]
        {
            get
            {
                var hash = Hash(key);
                for (var x = s[hash]; x != null; x = x.next)
                {
                    if (x.key .Equals( key))
                    {
                        return x.value;
                    }
                }
                return default(V);
            }
            set
            {
                var hash = Hash(key);
                for (var x = s[hash]; x != null; x = x.next)
                {
                    if (!x.key.Equals(key)) continue;
                    x.value = value;
                    return;
                }

                var old = s[hash];
                s[hash] = new Node<K, V>
                {
                    key = key,
                    value = value,
                    next = old
                };
                N++;


            }
        }

        private int Hash(K key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }

        public bool ContainsKey(K key)
        {
            var hash = Hash(key);
            return !this[key].Equals(default(V));
        }

        public int Count => N;
        public bool IsEmpty => N == 0;
        public void Delete(K key)
        {
            var hash = Hash(key);
            Node<K, V> prev = null;
            for (var x = s[hash]; x != null; x = x.next)
            {
                if (x.key.Equals(key))
                {
                    if (prev == null)
                    {
                        s[hash] = x.next;
                    }
                    else
                    {
                        prev.next = x.next;
                    }

                    N--;
                    break;
                }
                prev = x;
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                var keys = new List<K>();
                for (var h = 0; h < M; ++h)
                {
                    for (var x = s[h]; x != null; x = x.next)
                    {
                        keys.Add(x.key);
                    }
                }
                return keys;
            }
        }
    }
}