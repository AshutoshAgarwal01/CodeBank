using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBank.Misc
{
    public class ThreeSumClosest
    {
        public static int ThreeSumClosest_int(int[] nums, int target)
        {
            int gap =  target - (nums[0] + nums[1] + nums[2]);
            var cand = new int[] { nums[0], nums[1], nums[2] };
            for (int i = 0; i< nums.Length; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    for(int k = j + 1; k < nums.Length; k++)
                    {
                        if (Math.Abs(gap) > Math.Abs(target - (nums[i] + nums[j] + nums[k])))
                        {
                            gap = target - (nums[i] + nums[j] + nums[k]);
                            cand = new int[] { nums[i], nums[j], nums[k] };
                        }
                    }
                }
            }
            return cand[0] + cand[1] + cand[2];
        }

        /// <summary>
        /// Sort array first and then move 3 pointers.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int ThreeSumClosest_N2(int[] nums, int target)
        {
            var min_diff = int.MaxValue;
            var result = int.MaxValue;
            Array.Sort(nums);

            for(var i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;

                while(j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    int diff = sum - target;
                    if (diff == 0) return target;
                    min_diff = Math.Abs(diff) < Math.Abs(min_diff) ? diff : min_diff;
                    result = (min_diff == diff) ? sum : result;
                    if(target > sum )
                    {
                        j++;
                    }else
                    {
                        k-- ;
                    }
                }
            }

            return result;
        }
    }
}
