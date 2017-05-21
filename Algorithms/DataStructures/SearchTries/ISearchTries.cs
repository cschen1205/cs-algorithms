using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures.SearchTries
{
    public interface ISearchTries<T>
    {
        T this[string key] { get; set; }

        int Count { get; }
        bool IsEmpty { get;  }

        void Delete(String key);
        bool ContainsKey(String key);

        IEnumerable<string> Keys { get; }
        IEnumerable<string> KeysWithPrefix(string prefix);
    }
}