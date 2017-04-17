using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBank.Misc
{
    public class ThreeSumExact
    {
        public static List<List<int>> ThreeSumExact_BruteForce(List<int> nums, int target)
        {
            var result = new List<List<int>>();
            nums = nums.OrderBy(x => x).ToList();
            for (int i = 0; i <= nums.Count - 3; i++)
            {
                if (i > 0 && nums[i - 1] == nums[i])
                {
                    continue;
                }
                for (int j = i + 1; j <= nums.Count - 2; j++)
                {
                    if (j > i + 1 && nums[j - 1] == nums[j])
                    {
                        continue;
                    }
                    for (var k = j + 1; k <= nums.Count - 1; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == target)
                        {
                            result.Add(new List<int>() { nums[i], nums[j], nums[k] });
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public static IList<IList<int>> ThreeSumExact_N2(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i <= nums.Length - 3 && nums[i] <= target; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int j = i + 1;
                int k = nums.Length - 1;
                while(j < k)
                {
                    if (nums[i] + nums[j] + nums[k] > target) k--;
                    else if (nums[i] + nums[j] + nums[k] < target) j++;
                    else
                    {
                        result.Add(new List<int>() { nums[i], nums[j], nums[k] });
                        j++;
                        k--;
                        while (j < k && nums[j] == nums[j - 1]) j++;
                        while (j < k && nums[k] == nums[k + 1]) k--;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// TODO: remove duplicates and deal with runtime error.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> ThreeSumExact_N2_2(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            var dict = new Dictionary<int, int>();
            Array.Sort(nums);
            foreach(var d in nums)
            {
                if (dict.ContainsKey(d))
                    dict[d]++;
                else
                    dict.Add(d, 1);
            }
            
            for (int i = 0; i <= nums.Length - 3 && nums[i] <= target; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                if (dict[nums[i]] == 0) dict.Remove(nums[i]);
                else dict[nums[i]]--;

                for(int j = i+1; j <= nums.Length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                    if (dict[nums[j]] == 0) dict.Remove(nums[j]);
                    else dict[nums[j]]--;

                    var find = target - (nums[i] + nums[j]);
                    if (dict.ContainsKey(find))
                        result.Add(new List<int>() { nums[i], nums[j], find });
                }
            }
            return result;
        }
    }
}
