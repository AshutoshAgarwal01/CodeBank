using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBank.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBank.Sorting.Tests
{
    [TestClass()]
    public class BubbleTests
    {
        [TestMethod()]
        public void SortedDictionaryTest()
        {
            var nums = Bubble.Sort(new List<int>() { 7, 6, 5, 4, 3, 2, 1 });
            var x = 1;
        }
    }
}