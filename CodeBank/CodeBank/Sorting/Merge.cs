using System;
using System.Collections.Generic;

namespace CodeBank.Sorting
{
    public class Merge
    {
        public static void Sort(List<int> nums, int begin, int end)
        {
            if (nums == null || nums.Count <= 1 || begin == end)
                return;

            int mid = (begin + end) / 2;
            Sort(nums, begin, mid);
            Sort(nums, mid + 1, end);
            MergeLists(nums, begin, mid, end);
        }

        public static void MergeLists(List<int> nums, int begin, int mid, int end)
        {
            int i = begin, j = mid + 1;
            var result = new List<int>();
            while (i <= mid && j <= end)
            {
                result.Add(nums[i] < nums[j] ? nums[i++] : nums[j++]);
            }

            while (j <= end)
            {
                result.Add(nums[j++]);
            }
            while (i <= mid)
            {
                result.Add(nums[i++]);
            }

            i = begin;
            foreach(var r in result)
            {
                nums[i] = result[i - begin];
                i++;
            }
        }
    }
}
