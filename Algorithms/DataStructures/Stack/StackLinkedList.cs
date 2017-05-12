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
    }
}