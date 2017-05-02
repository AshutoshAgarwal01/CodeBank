using System;
using System.Collections.Generic;

namespace CodeBank.Sorting
{
    public class Heap
    {
        /// <summary>
        /// Sorts numbers
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="mode">
        /// 0 - asc
        /// 1 - desc
        /// </param>
        public static void Sort(List<int> nums, int mode)
        {
            int h = nums.Count;
            Build_Heap(nums, 0, h);
            for(int i = 0; i < nums.Count; i++)
            {
                Swap(nums, 0, h - 1);
                Min_Heapify(nums, 0, --h);
            }
            if(mode == 0)
            {
                for(int i = 0 , j = nums.Count - 1; i <= j; i++, j--)
                {
                    Swap(nums, i, j);
                }
            }
        }

        /// <summary>
        /// Time complexity 
        /// Simple Analysis O(n Log n)
        /// Tighter Analysis - O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="rootIndex"></param>
        /// <param name="heapSize"></param>
        public static void Build_Heap(List<int> nums, int rootIndex, int heapSize)
        {
            int firstNonLeaf = heapSize / 2 - 1;
            for(int i = firstNonLeaf; i >= 0; i--)
            {
                Min_Heapify(nums, i, heapSize);
            }
        }

        /// <summary>
        /// Assumes that left and right subtree are already min-heap.
        /// Time Complexity - O(Log n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="rootIndex"></param>
        /// <param name="heapSize"></param>
        public static void Min_Heapify(List<int> nums, int rootIndex, int heapSize)
        {
            int leftIndex = 2 * rootIndex + 1;
            int rightIndex = leftIndex + 1;
            int smallest = rootIndex;

            if (leftIndex < heapSize && nums[leftIndex] < nums[smallest])
                smallest = leftIndex;
            if (rightIndex < heapSize && nums[rightIndex] < nums[smallest])
                smallest = rightIndex;
            if(smallest != rootIndex)
            {
                Swap(nums, smallest, rootIndex);
                Min_Heapify(nums, smallest, heapSize);
            }
        }

        private static void Swap(List<int> nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
