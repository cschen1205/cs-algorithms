using System;

namespace DataStructures.Stack
{
    public class StackArray<T> : IStack<T>
    {
        private T[] s = new T[10];
        private int N = 0;

        public T Pop()
        {
            if (N == 0) return default(T);
            T item = s[--N];
            if (N == s.Length / 4) Resize(s.Length / 2);
            return item;
        }

        private void Resize(int len)
        {
            T[] temp = new T[len];
            for (var i = 0; i < Math.Min(len, s.Length); ++i)
            {
                temp[i] = s[i];
            }
            s = temp;

        }

        public void Push(T item)
        {
            s[N++] = item;
            if(N == s.Length) Resize(s.Length * 2);
        }

        public int Count => N;
        public bool IsEmpty => N == 0;
    }
}