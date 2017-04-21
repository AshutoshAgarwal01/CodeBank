using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBank.Misc
{
    public class TrappingRainWater
    {
        public static int TrappingRainWater_N(int[] height)
        {
            int totalArea = 0;
            int pi = 0;
            int inBetw = 0;

            //Forward
            for (int i = 1; i < height.Length; i++)
            {
                //Note that here we have less than condition whereas in backward loop we have less than equal to.
                //This is done to prevent doubling up those containers that had same height on both ends.
                if (height[i] > height[pi])
                {
                    totalArea += height[pi] * (i - pi - 1) - inBetw;
                    inBetw = 0;
                    pi = i;
                }
                else
                {
                    inBetw += height[i];
                }
            }

            //Backward
            pi = height.Length - 1;
            inBetw = 0;
            for (int i = height.Length - 2; i >= 0; i--)
            {
                if (height[i] >= height[pi])
                {
                    totalArea += height[pi] * (pi - i - 1) - inBetw;
                    inBetw = 0;
                    pi = i;
                }
                else
                {
                    inBetw += height[i];
                }
            }
            return totalArea;
        }
    }
}
