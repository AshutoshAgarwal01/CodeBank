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
    public class LongestPalindromicSubstringTests
    {
        [TestMethod()]
        public void LongestPalindromicSubstring_StringTest()
        {
            var str = "aaaabaaa";

            var longest = LongestPalindromicSubstring.LongestPalindromicSubstring_String(str);
            var x = 1;
        }
    }
}