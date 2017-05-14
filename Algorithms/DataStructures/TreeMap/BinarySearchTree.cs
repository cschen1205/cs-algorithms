using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Algorithms.DataStructures.Queue;

namespace Algorithms.DataStructures.TreeMap
{
    public class Node<K, V> where K : IComparable<K>
    {
        internal K key;
        internal V value;
        internal Node<K, V> left;
        internal Node<K, V> right;
        internal int count = 0;
        internal bool isRed = false;
    }

    public class BinarySearchTree<K, V> : ITreeMap<K, V> where K : IComparable<K>
    {

        private Node<K, V> root;

        public void Put(K key, V value)
        {
            root = Put(root, key, value);
        }

        protected virtual Node<K, V> Put(Node<K, V> x, K key, V value)
        {
            if (x == null)
            {
                return new Node<K, V>
                {
                    key = key,
                    value = value,
                    count = 1
                };
            }

            var cmp = key.CompareTo(x.key);

            if (cmp < 0)
            {
                x.left = Put(x.left, key, value);
            } else if (cmp > 0)
            {
                x.right = Put(x.right, key, value);
            }
            else
            {
                x.value = value;
            }

            x.count = 1 + _Count(x.left) + _Count(x.right);

            return x;

        }

        public V Get(K key)
        {
            var x = Get(root, key);
            return x != null ? x.value : default(V);
        }

        private static Node<K, V> Get(Node<K, V> x, K key)
        {
            if (x == null) return null;
            var cmp = key.CompareTo(x.key);
            if (cmp < 0) return Get(x.left, key);
            if (cmp > 0) return Get(x.right, key);

            return x;
        }

        protected int _Count(Node<K, V> x)
        {
            return x == null ? 0 : x.count;
        }


        public void Delete(K key)
        {
            root = Delete(root, key);
        }

        private Node<K, V> Delete(Node<K, V> x, K key)
        {
            if (x == null) return null;

            var cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = Delete(x.left, key);
            else if (cmp > 0) x.right = Delete(x.right, key);
            else
            {
                if (x.left == null) return x.right;
                if (x.right == null) return x.left;

                var m = Min(x.right);
                m.right = DelMin(x.right);
                m.left = x.left;

                x = m;
            }

            x.count = 1 + _Count(x.left) + _Count(x.right);

            return x;
        }

        private Node<K, V> DelMin(Node<K, V> x)
        {
            if (x.left == null)
            {
                return x;
            }
            x.left = DelMin(x.left);

            x.count = 1 + _Count(x.left) + _Count(x.right);
            return x;
        }

        private Node<K, V> Min(Node<K, V> x)
        {
            if (x.left == null)
            {
                return x;
            }
            return Min(x.left);
        }


        public V this[K key]
        {
            get => Get(key);
            set => Put(key, value);
        }

        public int Count => _Count(root);
        public bool IsEmpty => _Count(root) == 0;

        public bool ContainsKey(K key)
        {
            var x = Get(root, key);
            return x != null;

        }

        public K MinKey()
        {
            var x = Min(root);
            if (x == null) return default(K);
            return x.key;
        }

        public IEnumerable<K> Keys
        {
            get
            {
                IQueue<K> queue = new QueueLinkedList<K>();
                Collect(root, queue);
                return queue;
            }
        }

        private void Collect(Node<K, V> x, IQueue<K> queue)
        {
            if (x == null) return;
            Collect(x.left, queue);
            queue.Enqueue(x.key);
            Collect(x.right,queue);
        }
    }
}