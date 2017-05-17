using System;
using System.Collections;
using System.Collections.Generic;
using Algorithms.Sorting;
using Algorithms.Utils;

namespace Algorithms.DataStructures.Queue
{
    public class IndexMinPQ<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] keys;
        private int[] pq;
        private int[] qp;
        private int N = 0;

        public IndexMinPQ(int N)
        {
            keys = new T[N+1];
            pq = new int[N + 1];
            qp = new int[N + 1];
            for (var i = 0; i <= N; ++i)
            {
                qp[i] = -1;
            }
        }

        public IndexMinPQ(T[] keys, int[] pq, int[] qp, int N)
        {
            this.keys = (T[]) keys.Clone();
            this.pq = (int[]) pq.Clone();
            this.qp = (int[]) qp.Clone();
            this.N = N;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new IndexMinPQEnumerator(keys, pq, qp, N);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T MinKey()
        {
            return keys[pq[1]];
        }

        public int DelMin()
        {
            var item = pq[1];
            SortUtil.Exchange(pq, 1, N);
            qp[pq[1]] = 1;
            qp[pq[N]] = N;
            N--;
            Sink(1);
            return item;
        }

        public void Enqueue(int index, T item)
        {
            var p = qp[index];
            if (p == -1)
            {
                Insert(index, item);
            }
            else
            {
                if (SortUtil.IsLessThan(keys[index], item))
                {
                    keys[index] = item;
                    Sink(p);
                }
                else
                {
                    keys[index] = item;
                    Swim(p);
                }
            }
        }

        public void DecreaseKey(int index, T item)
        {
            int p = qp[index];
            if (SortUtil.IsGreaterThan(keys[index], item))
            {
                keys[index] = item;
                Swim(p);
            }
        }

        public bool Contains(int index)
        {
            return qp[index] == -1;
        }

        private void Sink(int k)
        {
            while (k * 2 <= N)
            {
                int child = 2 * k;
                if (child < N && SortUtil.IsLessThan(keys[pq[child + 1]], keys[pq[child]]))
                {
                    child++;
                }
                if (SortUtil.IsLessThan(keys[pq[child]], keys[pq[k]]))
                {
                    SortUtil.Exchange(pq, child, k);
                    qp[pq[child]] = child;
                    qp[pq[k]] = k;
                    k = child;
                }
                else
                {
                    break;
                }
            }
        }

        public void Insert(int index, T item)
        {
            keys[index] = item;
            pq[++N] = index;
            qp[index] = pq[N];
            Swim(N);
        }

        private void Swim(int k)
        {
            while (k > 1)
            {
                var parent = k / 2;
                if (SortUtil.IsLessThan(keys[pq[k]], keys[pq[parent]]))
                {
                    SortUtil.Exchange(pq, k, parent);

                    qp[pq[k]] = k;
                    qp[pq[parent]] = parent;

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

        private class IndexMinPQEnumerator : IEnumerator<T>
        {
            private T[] keys;
            private int[] pq;
            private int[] qp;
            private int N;
            private T value;

            private IndexMinPQ<T> current;


            public IndexMinPQEnumerator(T[] keys, int[] pq, int[] qp, int N)
            {
                this.keys = keys;
                this.pq = pq;
                this.qp = qp;
                this.N = N;
                current = new IndexMinPQ<T>(keys,pq, qp, N);
            }

            public bool MoveNext()
            {
                if (current.IsEmpty) return false;
                value = current.MinKey();
                current.DelMin();
                return true;
            }

            public void Reset()
            {
                current = new IndexMinPQ<T>(keys, pq, qp, N);
            }

            public T Current => value;

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