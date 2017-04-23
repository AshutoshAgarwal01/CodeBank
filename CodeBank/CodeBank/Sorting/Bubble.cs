using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBank.Sorting
{
    public class Bubble
    {
        public static List<int> Sort(List<int> nums)
        {
            for(int i = 0; i < nums.Count - 1; i++)
            {
                for(int j = 1; j < nums.Count; j++)
                {
                    if(nums[j - 1] > nums[j])
                    {
                        var temp = nums[j - 1];
                        nums[j - 1] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            return nums;
        }
    }
}
