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
    public class MatchExpressionTests
    {
        [TestMethod()]
        public void MatchTest()
        {
            MatchExpression me = new MatchExpression();
            var x = 1;
        }

        [TestMethod()]
        public void GetAllStringsTest()
        {
            MatchExpression me = new MatchExpression();
            var result = me.GetAllExpressions();
            var x = 1;
        }

        [TestMethod()]
        public void MatchTest_Positive_1()
        {
            MatchExpression me = new MatchExpression();
            var actual = me.ExactMatch("Hello {0}");
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void MatchTest_Positive_2()
        {
            MatchExpression me = new MatchExpression();
            var actual = me.ExactMatch("Hello {0} world.");
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void MatchTest_Negative_1()
        {
            MatchExpression me = new MatchExpression();
            var actual = me.ExactMatch("Hello");
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void MatchTest_Negative_2()
        {
            MatchExpression me = new MatchExpression();
            var actual = me.ExactMatch("Hello {0} baby.");
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void MatchTest_Negative_3()
        {
            MatchExpression me = new MatchExpression();
            var actual = me.ExactMatch("Hello {0} little baby.");
            Assert.IsFalse(actual);
        }
    }
}