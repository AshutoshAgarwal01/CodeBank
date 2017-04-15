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
    public class LongestValidParenthesesTests
    {
        [TestMethod()]
        public void LongestValidParenthesesCountTest()
        {
            //Arrange
            string input = "()(()";
            var expected = 2;

            //Act
            var actual = LongestValidParentheses.LongestValidParenthesesCount_O1(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LongestValidParenthesesCount_Test2()
        {
            //Arrange
            string input = ")(()()))(())(()(()()())())))(((((()()()((()))())(((()((())()(()(())))()()))()())((()((()(((((((()))(()()()))(()(()(()())(()(((()))))(((())()()(((())(()((((((()()))()((()(())(()())()(((((()(()))()(((";
            var expected = 48;

            //Act
            var actual = LongestValidParentheses.LongestValidParenthesesCount_O1(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}