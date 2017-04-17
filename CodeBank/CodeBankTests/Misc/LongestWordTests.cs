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
    public class LongestWordTests
    {
        [TestMethod()]
        public void FindLongestWordTest()
        {
            var inputWord = "bab";
            var dict = new List<string>() { "ba", "ab", "a", "b" };

            var result = LongestWord.FindLongestWord(inputWord, dict);
            var res = 1;
        }
    }
}