using System.Reflection.PortableExecutable;
using Algorithms.DataStructures.TreeMap;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.DataStrutures.TreeMap
{
    public class LeftLeaningRedBlackTreeUnitTest
    {
        private ITestOutputHelper console;
        public LeftLeaningRedBlackTreeUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void TestTreeMap()
        {
            var map = new LeftLeaningRedBlackTree<int, int>();
            map[1] = 1;
            Assert.Equal(1, map[1]);
            map[2] = 2;
            Assert.Equal(2, map[2]);
            Assert.Equal(2, map.Count);

            map.Delete(2);
            Assert.Equal(1, map.Count);
            Assert.True(map.ContainsKey(1));
            Assert.False(map.ContainsKey(2));

            for (var i = 3; i < 100; ++i)
            {
                map[i] = i;
            }

            Assert.True(map.ContainsKey(1));
            for (var i = 3; i < 100; ++i)
            {
                Assert.True(map.ContainsKey(i));
            }

            Assert.Equal(98, map.Count);
        }
    }
}