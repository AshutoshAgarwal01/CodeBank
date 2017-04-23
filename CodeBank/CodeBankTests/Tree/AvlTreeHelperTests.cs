using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBank.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBank.Tree.Tests
{
    [TestClass()]
    public class AvlTreeHelperTests
    {
        [TestMethod()]
        public void InsertNodeTest()
        {
            var root = new AvlTreeNode(7);
            root = AvlTreeHelper.InsertNode(root, 6);
            root = AvlTreeHelper.InsertNode(root, 5);
            root = AvlTreeHelper.InsertNode(root, 4);
            root = AvlTreeHelper.InsertNode(root, 3);
            root = AvlTreeHelper.InsertNode(root, 2);
            root = AvlTreeHelper.InsertNode(root, 1);
            var x = 1;
        }
    }
}