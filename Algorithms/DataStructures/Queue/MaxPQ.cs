using System;
using System.Runtime.InteropServices.ComTypes;
using Algorithms.Utils;

namespace Algorithms.DataStructures.Queue
{
    public class MaxPQ<T> : IQueue<T>
    where T : IComparable<T>
    {
        private T[] s = new T[20];
        private int N = 0;

        public T Dequeue()
        {
            return DelMax();
        }

        public T DelMax()
        {
            if (IsEmpty)
            {
                return default(T);
            }

            var item = s[1];
            SortUtil.Exchange(s, 1, N--);
            Sink(1);
            if(N < s.Length / 4) Resize(s.Length / 2);
            return item;
        }

        private void Sink(int k)
        {
            while (2 * k < N)
            {
                int child = k * 2;
                if (child < N && SortUtil.IsGreaterThan(s[child + 1], s[child]))
                {
                    child++;
                }
                if (SortUtil.IsGreaterThan(s[child], s[k]))
                {
                    SortUtil.Exchange(s, child, k);
                    k = child;
                }
                else
                {
                    break;
                }
            }
        }


        public void Enqueue(T item)
        {
            if (N == s.Length - 1) Resize(s.Length * 2);
            s[++N] = item;
            Swim(N);
        }

        private void Resize(int len)
        {
            var temp = new T[len];
            for (var i = 0; i < Math.Min(len, s.Length); ++i)
            {
                temp[i] = s[i];
            }
            s = temp;
        }

        private void Swim(int k)
        {
            while (k > 1)
            {
                var parent = k / 2;
                if (SortUtil.IsGreaterThan(s[k], s[parent]))
                {
                    SortUtil.Exchange(s, k, parent);
                    k = parent;
                }
                else
                {
                    break;
                }
             }
        }

        public int Count => N;
        public bool IsEmpty => N == 0;
    }
}