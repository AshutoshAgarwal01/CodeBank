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
    public class MergeTests
    {
        [TestMethod()]
        public void SortTest()
        {
            var nums = new List<int>() { 100, 45, 35, 200, -1, -15, 195 };
            Merge.Sort(nums, 0, nums.Count - 1);
            var x = 1;
        }
    }
}