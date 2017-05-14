﻿using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures.TreeMap
{
    internal class Node<K, V> where K : IComparable<K>
    {
        internal K key;
        internal V value;
        internal Node<K, V> left;
        internal Node<K, V> right;
    }

    public class BinarySearchTree<K, V> where K : IComparable<K>
    {

        private Node<K, V> root;
        private int N = 0;

        public void Put(K key, V value)
        {
            root = Put(root, key, value);
        }

        private Node<K, V> Put(Node<K, V> x, K key, V value)
        {
            if (x == null)
            {
                N++;
                return new Node<K, V>
                {
                    key = key,
                    value = value
                };
            }

            int cmp = key.CompareTo(x.key);

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

            return x;

        }

        public V Get(K key)
        {
            Node<K, V> x = Get(root, key);
            if (x != null)
            {
                return x.value;
            }
            else
            {
                return default(V);
            }
        }

        private static Node<K, V> Get(Node<K, V> x, K key)
        {
            if (x == null) return null;
            var cmp = key.CompareTo(x.key);
            if (cmp < 0) return Get(x.left, key);
            if (cmp > 0) return Get(x.right, key);

            return x;
        }

        
    }
}