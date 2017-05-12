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
    }
}