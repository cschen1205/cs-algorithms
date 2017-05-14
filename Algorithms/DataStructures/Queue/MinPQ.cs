using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Algorithms.Utils;

namespace Algorithms.DataStructures.Queue
{
    public class MinPQ<T> : IQueue<T>
    where T : IComparable<T>
    {
        private T[] s = new T[20];
        private int N = 0;

        public T Dequeue()
        {
            return DelMin();
        }

        public T DelMin()
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
                if (child < N && SortUtil.IsLessThan(s[child + 1], s[child]))
                {
                    child++;
                }
                if (SortUtil.IsLessThan(s[child], s[k]))
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
                if (SortUtil.IsLessThan(s[k], s[parent]))
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

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(s, N);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class QueueEnumerator : IEnumerator<T>
        {
            private T[] values;
            private int current = 0;

            public QueueEnumerator(T[] s, int N)
            {
                s = (T[]) s.Clone();
                this.values = new T[N];
                int k = 0;
                while (N > 0)
                {
                    values[k++] = s[1];
                    SortUtil.Exchange(s, 1, N--);
                    Sink(s, 1, N);
                }
            }

            private void Sink(T[] s, int k, int N)
            {
                while (k * 2 <= N)
                {
                    int child = k * 2;
                    if (child < N && SortUtil.IsLessThan(s[child + 1], s[child]))
                    {
                        child++;
                    }
                    if (SortUtil.IsLessThan(s[child], s[k]))
                    {
                        SortUtil.Exchange(s, k, child);
                        k = child;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            public bool MoveNext()
            {
                if (current == values.Length)
                {
                    return false;
                }

                current++;
                return true;
            }

            public void Reset()
            {
                current = 0;
            }

            public T Current => values[current];

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {

            }
        }
    }
}