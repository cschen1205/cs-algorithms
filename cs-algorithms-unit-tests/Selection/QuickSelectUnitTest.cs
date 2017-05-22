using System.Collections.Generic;
using System.Numerics;
using SimuKit.Algorithms.Selection;
using Xunit;

namespace AlgorithmsUnitTest.Selection
{
    public class QuickSelectUnitTest
    {

        [Fact]
        public void testSelectK()
        {
            var a = new[]
            {
                1, 3, 5, 2, 4, 6, 0
            };

            Assert.Equal(3, QuickSelect.Select(a, 3, (a1, b) => a1 - b));
        }
    }
}