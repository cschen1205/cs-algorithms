using Algorithms.DataStructures.HashMap;

namespace Algorithms.DataStructures.HashSet
{
    public class HashSetWithSeparateChaining<T> : HashMapWithSeparateChaining<T,T>
    {
        public void Add(T item)
        {
            this[item] = item;
        }

        public bool Contains(T item)
        {
            return ContainsKey(item);
        }
    }
}