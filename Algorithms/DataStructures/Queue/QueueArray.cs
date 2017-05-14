using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Algorithms.DataStructures.Queue
{
    public class QueueArray<T> : IQueue<T>
    {
        private T[] s = new T[20];
        private int head = 0;
        private int tail = 0;

        public T Dequeue()
        {
            if (IsEmpty)
            {
                return default(T);
            }
            var item = s[head++];
            if (Count < s.Length / 4) Resize(s.Length / 4);
            return item;
        }

        private void Resize(int len)
        {
            var temp = new T[len];
            for (var i = head; i < tail; ++i)
            {
                temp[i - head] = s[i];
            }
            tail = tail - head;
            head = 0;
            s = temp;
        }

        public void Enqueue(T item)
        {
            s[tail++] = item;
            if(tail == s.Length) Resize(s.Length * 2);
        }

        public int Count => tail - head;
        public bool IsEmpty => tail - head == 0;

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(s, head, tail);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class QueueEnumerator : IEnumerator<T>
        {
            private int current;
            private T[] s;
            private int head;
            private int tail;

            public QueueEnumerator(T[] s, int head, int tail)
            {
                current = head;
                this.head = head;
                this.tail = tail;
                this.s = s;
            }

            public bool MoveNext()
            {
                if (current == tail) return false;
                current++;
                return true;
            }

            public void Reset()
            {
                current = head;
            }

            public T Current => s[current];

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