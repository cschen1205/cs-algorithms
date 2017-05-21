

using System;
using System.Collections;
using System.Collections.Generic;
using Algorithms.DataStructures.Queue;
using Algorithms.Utils;

namespace Algorithms.DataStructures.SearchTries
{
    public class RWayTries<T> : ISearchTries<T>
    {
        private const int R = 256;
        private int N = 0;

        private class Node
        {
            internal T value;
            internal Node[] children = new Node[R];
        }

        private Node root;

        public T this[string key]
        {
            get
            {
                var x = Get(root, key, 0);
                if (x != null)
                {
                    return x.value;
                }
                return default(T);
            }
            set
            {
                root = Put(root, key, value, 0);

            }
        }

        private Node Put(Node x, string key, T value, int d)
        {
            if (x == null)
            {
                x = new Node();
            }

            if (key.Length == d)
            {
                if (ObjectUtil.IsNullOrDefault(x.value))
                {
                    N++;
                }

                x.value = value;
                return x;
            }

            char v = key[d];
            x.children[v] = Put(x.children[v], key, value, d + 1);
            return x;
        }

        public void Delete(String key)
        {
            Node x = Get(root, key, 0);
            if (x != null)
            {
                N--;
                x.value = default(T);
            }
        }

        public bool ContainsKey(String key)
        {
            Node x = Get(root, key, 0);
            if (x == null) return false;
            return !ObjectUtil.IsNullOrDefault(x.value);
        }

        public IEnumerable<string> Keys {
            get
            {
                var queue = new QueueLinkedList<string>();

                Collect(root, "", queue);

                return queue;
            }
        }

        public IEnumerable<string> KeysWithPrefix(string prefix)
        {

            Node x = Get(root, prefix, 0);
            QueueLinkedList<String> queue = new QueueLinkedList<string>();
            if (x != null)
            {
                Collect(x, prefix, queue);
            }
            return queue;
        }

        private void Collect(Node x, String prefix, IQueue<string> queue)
        {
            if (x == null) return;
            if (!ObjectUtil.IsNullOrDefault(x.value))
            {
                queue.Enqueue(prefix);
            }
            for (int r = 0; r < R; ++r)
            {
                Collect(x.children[r], prefix + ((char)r), queue);
            }
        }

        private Node Get(Node x, string key, int d)
        {
            if (x == null) return null;
            if (key.Length == d) return x;
            char v = key[d];
            return Get(x.children[v], key, d + 1);
        }

        public int Count => N;
        public bool IsEmpty => N == 0;


    }
}