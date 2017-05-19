using System;
using Algorithms.Strings.Sort;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.Strings.Sort
{
    public class MSDUnitTest
    {
        private ITestOutputHelper console;
        public MSDUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void Test()
        {

            var words= "bed bug dad yes zoo now for tip ilk dim tag jot sob nob sky hut men egg few jay owl joy rap gig wee was wad fee tap tar dug jam all bad yet".Split(' ');
            MSD.Sort(words);

            for (var i = 0; i < words.Length; ++i)
            {
                console.WriteLine(words[i]);
                Console.WriteLine(words[i]);
            }

        }
    }
}