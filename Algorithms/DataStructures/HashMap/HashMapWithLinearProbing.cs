using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures.HashMap
{
    public class HashMapWithLinearProbing<K, V> : IHashMap<K, V>
    {
        private int N;
        private Node<K, V>[] s;

        public HashMapWithLinearProbing()
        {
            s = new Node<K, V>[97];
        }

        public HashMapWithLinearProbing(int len)
        {
            s = new Node<K, V>[len];
        }

        private int Hash(K key)
        {
            return (key.GetHashCode() & 0x7fffffff) % s.Length;
        }

        public V this[K key]
        {
            get
            {
                var hash = Hash(key);
                for (var x = s[hash]; x != null; x = s[(++hash) % s.Length])
                {
                    if (x.key.Equals(key))
                    {
                        return x.value;
                    }
                }
                return default(V);
            }
            set
            {
                var hash = Hash(key);
                for (var x = s[hash]; x != null; x = s[(++hash) % s.Length])
                {
                    if (x.key.Equals(key))
                    {
                        x.value = value;
                        return;
                    }
                }
                s[hash % s.Length] = new Node<K, V>
                {
                    key = key,
                    value = value
                };
                N++;
                if (s[(hash + 1) % s.Length] != null)
                {
                    Resize(s.Length * 2);
                }
            }
        }

        private void Resize(int len)
        {
            var temp = new HashMapWithLinearProbing<K, V>(len);
            for (var h = 0; h < s.Length; ++h)
            {
                temp[s[h].key] = s[h].value;
            }
            s = temp.s;
        }

        public bool ContainsKey(K key)
        {
            return !this[key].Equals(default(V));
        }

        public int Count => N;
        public bool IsEmpty => N == 0;
        public void Delete(K key)
        {
            var hash = Hash(key);
            for (var x = s[hash]; x != null; x = s[(++hash) % s.Length])
            {
                if (x.key.Equals(key))
                {
                    s[hash % s.Length] = null;
                    N--;
                    if (N == s.Length / 4)
                    {
                        Resize(s.Length / 2);
                    }
                    break;
                }
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                var keys = new List<K>();
                for (var h = 0; h < s.Length; ++h)
                {
                    if (s[h] == null) continue;
                  keys.Add(s[h].key);
                }
                return keys;
            }
        }
    }
}