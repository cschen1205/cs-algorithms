using System;
using System.Collections.Generic;
using Algorithms.Utils;

namespace Algorithms.DataStructures.SearchTries
{
    public class TernarySearchTries<T> : ISearchTries<T>
    {
        private class Node
        {
            internal char key;
            internal T value;
            internal Node left;
            internal Node mid;
            internal Node right;
        }

        private Node root;
        private int N;

        public T this[string key]
        {
            get
            {
                Node x = Get(root, key, 0);
                if (x != null)
                {
                    return x.value;
                }
                return default(T);
            }
            set { root = Put(root, key, value, 0); }
        }

        private Node Put(Node x, string key, T value, int d)
        {
            if (x == null)
            {
                x = new Node
                {
                    key = key[d]
                };
            }

            int cmp = key[d].CompareTo(x.key);
            if (cmp < 0)
            {
                x.left = Put(x.left, key, value, d);
            } else if (cmp > 0)
            {
                x.right = Put(x.right, key, value, d);
            }
            else
            {
                if (d >= key.Length-1)
                {
                    if (ObjectUtil.IsNullOrDefault(x.value))
                    {
                        N++;
                    }
                    x.value = value;
                }
                else
                {
                    x.mid = Put(x.mid, key, value, d + 1);
                }
            }
            return x;
        }

        private Node Get(Node x, string key, int d)
        {
            if (x == null)
            {
                return null;
            }

            int cmp = key[d].CompareTo(x.key);

            if (cmp < 0) return Get(x.left, key, d);
            if (cmp > 0) return Get(x.right, key, d);
            if (key.Length - 1 == d)
            {
                return x;
            }
            return Get(x.mid, key, d + 1);
        }

        public int Count => N;
        public bool IsEmpty => N == 0;
        public void Delete(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> Keys { get; }
        public IEnumerable<string> KeysWithPrefix(string prefix)
        {
            throw new System.NotImplementedException();
        }
    }
}