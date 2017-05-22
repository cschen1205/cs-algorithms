using System.Reflection.PortableExecutable;
using Algorithms.DataStructures.HashMap;
using Algorithms.DataStructures.SearchTries;
using Algorithms.DataStructures.TreeMap;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.DataStrutures.TreeMap
{
    public class TernarySearchTriesUnitTest
    {
        private ITestOutputHelper console;
        public TernarySearchTriesUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void TestSearchTries()
        {
            var map = new TernarySearchTries<int>();
            Assert.True(map.IsEmpty);
            map["one"] = 1;
            Assert.Equal(1, map["one"]);
            map["two"] = 2;
            Assert.Equal(2, map["two"]);
            Assert.Equal(2, map.Count);



            map.Delete("two");
            Assert.Equal(1, map.Count);
            Assert.True(map.ContainsKey("one"));
            Assert.False(map.ContainsKey("two"));
            Assert.False(map.IsEmpty);



            foreach(var key in map.Keys)
            {
                console.WriteLine("{0}", key);
            }


            map["test"] = 3;
            map["te"] = 4;
            map["team"] = 4;
            map["dream"] = 2;

            int count = 0;
            foreach (var key in map.KeysWithPrefix("te"))
            {
                count++;
                console.WriteLine("{0}", key);
            }
            Assert.Equal(3, count);
        }
    }
}