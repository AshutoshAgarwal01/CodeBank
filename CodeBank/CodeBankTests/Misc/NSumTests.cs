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
    public class NSumTests
    {
        [TestMethod()]
        public void NSum_RecTest()
        {
            NSum.NSum_Rec(new int[] { 1, 0, -1, 0, -2, 2}, 0);
        }
    }
}