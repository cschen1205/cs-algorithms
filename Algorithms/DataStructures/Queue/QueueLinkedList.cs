using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures.Queue
{
    internal class QueueNode<T>
    {
        internal T item;
        internal QueueNode<T> Next;
    }

    public class QueueLinkedList<T> : IQueue<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;
        private int N = 0;

        public T Dequeue()
        {
            QueueNode<T> oldHead = head;
            if (oldHead == null)
            {
                return default(T);
            }
            head = oldHead.Next;
            N--;
            if (head == null)
            {
                tail = null;
            }
            return oldHead.item;
        }

        public void Enqueue(T item)
        {
            var oldTail = tail;
            tail = new QueueNode<T>
            {
                item = item
            };
            if (oldTail != null)
            {
                oldTail.Next = tail;
            }
            if (head == null)
            {
                head = tail;
            }
            N++;
        }

        public int Count => N;
        public bool IsEmpty => N == 0;
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class QueueEnumerator : IEnumerator<T>
        {
            private QueueNode<T> head;
            private QueueNode<T> current;
            private T value;
            public QueueEnumerator(QueueNode<T> head)
            {
                this.head = head;
                this.current = head;
            }
            public bool MoveNext()
            {
                if (current == null) return false;
                value = current.item;
                current = current.Next;
                return true;
            }

            public void Reset()
            {
                current = head;
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