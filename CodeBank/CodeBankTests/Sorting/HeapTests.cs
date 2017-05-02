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
    public class HeapTests
    {
        [TestMethod()]
        public void Min_HeapifyTest()
        {
            var input = new List<int>() { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1 };
            Heap.Min_Heapify(input, 0, input.Count - 1);
        }

        [TestMethod()]
        public void HeapSortTest_Asc()
        {
            var input = new List<int>() { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1 };
            var expected = new List<int>() { -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Heap.Sort(input, 0);
            for (int i = 0; i < input.Count; i++)
            {
                Assert.AreEqual(input[i], expected[i]);
            }
        }

        [TestMethod()]
        public void HeapSortTest_Desc()
        {
            var input = new List<int>() { -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var expected = new List<int>() { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1 };
            Heap.Sort(input, 1);
            for (int i = 0; i < input.Count; i++)
            {
                Assert.AreEqual(input[i], expected[i]);
            }
        }

        [TestMethod()]
        public void Build_HeapTest()
        {
            var input = new List<int>() { 10, -1, 20, 3, 45, 4, 56, 57, 12, 65 };
            Heap.Build_Heap(input, 0, input.Count);
            var x = 1;
        }
    }
}