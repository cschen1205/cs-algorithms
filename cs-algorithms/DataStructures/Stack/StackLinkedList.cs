using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace DataStructures.Stack
{
    public class StackNode<T>
    {
        internal T item;
        internal StackNode<T> Next;
    }

    public class StackLinkedList<T> : IStack<T>
    {
        private StackNode<T> first;
        private int N = 0;

        public T Pop()
        {
            if (first == null) return default(T);
            var oldFirst = first;
            first = oldFirst.Next;
            N--;
            return oldFirst.item;
        }

        public void Push(T item)
        {
            var oldFirst = first;
            first = new StackNode<T>
            {
                item = item,
                Next = oldFirst
            };
            N++;
        }

        public int Count => N;

        public bool IsEmpty => Count == 0;
        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator(first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class StackEnumerator : IEnumerator<T>
        {
            private T value;
            private StackNode<T> current;
            private StackNode<T> first;

            public StackEnumerator(StackNode<T> first)
            {
                this.first = first;
                this.current = first;
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
                current = first;
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