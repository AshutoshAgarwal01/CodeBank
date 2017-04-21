using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBank.Misc
{
    public class ContanerWithMostWater
    {
        public static int ContanerWithMostWater_N(int[] height)
        {
            int maxSoFar = 0;

            //find larger pole than current in forward direction keeping maxArea updated.
            for (int i = 0, j = height.Length - 1; i < j;)
            {
                if (i > 0 && height[i] < height[i - 1])
                {
                    i++;
                }
                else if (height[j] >= height[i])
                {
                    int area = height[i] * (j - i);
                    maxSoFar = Math.Max(area, maxSoFar);
                    i++;
                }
                else
                {
                    j--;
                }
            }

            //find larger pole than current in reverse direction keeping maxArea updated.
            for (int j = 0, i = height.Length - 1; i > j;)
            {
                if (i < height.Length - 1 && height[i] < height[i + 1])
                {
                    i--;
                }
                else if (height[j] >= height[i])
                {
                    int area = height[i] * (i - j);
                    maxSoFar = Math.Max(area, maxSoFar);
                    i--;
                }
                else
                {
                    j++;
                }
            }
            return maxSoFar;
        }

        public static int ContanerWithMostWater_N_App2(int[] height)
        {
            int maxSoFar = 0;

            //Move pointer away from smaller pole.
            for (int i = 0, j = height.Length - 1; i < j;)
            {
                int h = Math.Min(height[i], height[j]);
                maxSoFar = Math.Max((j - 1) * h, maxSoFar);
                if(height[i] < height[j])
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return maxSoFar;
        }
    }
}
