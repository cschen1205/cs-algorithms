using System;
using Algorithms.Strings.Sort;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.Strings.Sort
{
    public class LSDUnitTest
    {
        private ITestOutputHelper console;
        public LSDUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void Test()
        {

            var words= "bed bug dad yes zoo now for tip ilk dim tag jot sob nob sky hut men egg few jay owl joy rap gig wee was wad fee tap tar dug jam all bad yet".Split(' ');
            LSD.Sort(words);

            for (var i = 1; i < words.Length; ++i)
            {
                Assert.True(words[i-1].CompareTo(words[i]) <= 0);
            }

        }
    }
}