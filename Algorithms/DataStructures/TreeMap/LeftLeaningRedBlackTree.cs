using System;

namespace Algorithms.DataStructures.TreeMap
{
    public class LeftLeaningRedBlackTree<K, V> : BinarySearchTree<K, V> where K : IComparable<K>
    {
        protected virtual Node<K, V> Put(Node<K, V> x, K key, V value)
        {
            if (x == null)
            {
                return new Node<K, V>
                {
                    key = key,
                    value = value,
                    count = 1,
                    isRed = true
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

            if (isRed(x.right) && !isRed(x.left)) x = rotateLeft(x);
            if (isRed(x.left) && isRed(x.left.left)) x = rotateRight(x);
            if (isRed(x.left) && isRed(x.right)) flipColor(x);


            x.count = 1 + _Count(x.left) + _Count(x.right);

            return x;

        }

        private bool isRed(Node<K, V> x)
        {
            if (x == null) return false;
            return x.isRed;
        }

        private void flipColor(Node<K, V> x)
        {
            if (x.left != null) x.left.isRed = false;
            if (x.right != null) x.right.isRed = false;
            x.isRed = true;

        }

        private Node<K, V> rotateLeft(Node<K, V> x)
        {
            var m = x.right;
            x.right = m.left;
            m.left = x;
            m.isRed = x.isRed;
            x.isRed = true;

            x.count = 1 + _Count(x.left) + _Count(x.right);

            return m;
        }

        private Node<K, V> rotateRight(Node<K, V> x)
        {
            var m = x.left;
            x.left = m.right;
            m.right = x;

            m.isRed = x.isRed;
            x.isRed = true;

            x.count = 1 + _Count(x.left) + _Count(x.right);

            return m;
        }
    }
}