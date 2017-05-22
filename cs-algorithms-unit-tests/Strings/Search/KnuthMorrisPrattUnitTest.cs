using System;
using Algorithms.Strings.Search;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsUnitTest.Strings.Search
{
    public class KnuthMorrisPrattUnitTest
    {

        private ITestOutputHelper console;

        public KnuthMorrisPrattUnitTest(ITestOutputHelper console)
        {
            this.console = console;
        }

        [Fact]
        public void Test()
        {
            String text = "o fare thee well, poor devil of a Sub-Sub, whose commen- \n" + "tator I am. Thou belongest to that hopeless, sallow tribe \n"
                          + "which no wine of this world will ever warm ; and for whom \n" + "even Pale Sherry would be too rosy-strong ; but with whom \n"
                          + "one sometimes loves to sit, and feel poor-devilish, too ; and \n"
                          + "grow convivial upon tears ; and say to them bluntly with full \n" + "eyes and empty glasses, and in not altogether unpleasant \n"
                          + "sadness Give it up, Sub-Subs ! For by how much the more \n" + "pains ye take to please the world, by so much the more shall \n"
                          + "ye forever go thankless ! Would that I could clear out \n" + "Hampton Court and the Tuileries for ye ! But gulp down \n"
                          + "your tears and hie aloft to the royal-mast with your hearts ; \n" + "for your friends who have gone before are clearing out the \n"
                          + "seven-storied heavens, and making refugees of long-pampered \n" + "Gabriel, Michael, and Raphael, against your coming. Here \n"
                          + "ye strike but splintered hearts together there, ye shall \n" + "strike unsplinterable glasses! ";

            KnuthMorrisPratt bm = new KnuthMorrisPratt("the");
            print("found at " + bm.Search(text));
            Assert.NotEqual(-1, bm.Search(text));
        }

        private void print(String content)
        {
            Console.WriteLine(content);
            console.WriteLine(content);
        }
    }
}