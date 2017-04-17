using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBank.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBank.Misc.Tests
{
    [TestClass()]
    public class ThreeSumClosestTests
    {
        [TestMethod()]
        public void ThreeSumClosest_N2Test()
        {
            var target = 82;
            var nums = new int[] {1, 2, 4, 8, 16, 32, 64, 128 };

            var x = ThreeSumClosest.ThreeSumClosest_N2(nums, target);
            var p = 1;
        }
    }
}