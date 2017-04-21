using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBank.Misc
{
    public class NSum
    {
        /// <summary>
        /// Can't be done better than O(n^3) with O(1) space.
        /// O(n^2 LogN) --> store sums of all pairs first. then sort the new array. Then find sums of sums that match target (discount any common element)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> NSum_Rec(int[] nums, int target)
        {
            return SomeFunc(nums.OrderBy(x => x).ToArray(), 0, target, 4);
        }

        private static IList<IList<int>> SomeFunc(int[] nums, int begin, int target, int numCount)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (numCount == 1)
            {
                for (int i = begin; i <= nums.Length - numCount; i++)
                {
                    if (target == nums[i])
                    {
                        result.Add(new List<int>() { target });
                        break;
                    }
                }
                return result;
            }

            for (int i = begin; i <= nums.Length - numCount; i++)
            {
                if (i > begin && nums[i] == nums[i - 1])
                {
                    continue;
                }
                var temp = SomeFunc(nums, i + 1, target - nums[i], numCount - 1);
                foreach (var t in temp)
                {
                    t.Add(nums[i]);
                    result.Add(t);
                }
            }
            return result;
        }

        private static IList<IList<int>> SomeFunc_Iter(int[] nums, int begin, int target, int numCount)
        {
            IList<IList<int>> result = new List<IList<int>>();

            nums = nums.OrderBy(x => x).ToArray();
            for (int i = 0; i <= nums.Length - 4; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                for (int j = i + 1; j <= nums.Length - 3; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                    for (int k = j + 1; k <= nums.Length - 2; k++)
                    {
                        if (k > j + 1 && nums[k] == nums[k - 1]) continue;
                        for (int l = k + 1; l <= nums.Length - 1; l++)
                        {
                            if (l > k + 1 && nums[l] == nums[l - 1]) continue;
                            if (nums[i] + nums[j] + nums[k] + nums[l] == target)
                            {
                                result.Add(new List<int>() { nums[i], nums[j], nums[k], nums[l] });
                            }
                        }
                    }
                }
            }

            return result;
        }

        private static IList<IList<int>> SomeFunc_N2(int[] nums, int begin, int target, int numCount)
        {
            IList<IList<int>> result = new List<IList<int>>();

            nums = nums.OrderBy(x => x).ToArray();
            for (int i = 0; i <= nums.Length - 4; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                for (int j = i + 1; j <= nums.Length - 3; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                    int newTarget = target - nums[i] - nums[j];

                    int k = j + 1, l = nums.Length - 1;
                    while(k < l)
                    {
                        if (k > j + 1 && nums[k] == nums[k - 1])
                        {
                            k++;
                            continue;
                        }
                        if (l < nums.Length - 1 && nums[l] == nums[l + 1])
                        {
                            l--;
                            continue;
                        }
                        if(nums[k] + nums[l] == newTarget)
                        {
                            result.Add(new List<int>() { nums[i], nums[j], nums[k], nums[l] });
                            k++;
                            l--;
                        }
                        else if(nums[k] + nums[l] < newTarget)
                        {
                            k++;
                        }
                        else
                        {
                            l--;
                        }
                    }
                }
            }

            return result;
        }


    }
}
