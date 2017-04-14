using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CodeBank.Tree.Tests
{
    [TestClass()]
    public class TreeNodeTests
    {
        [TestMethod()]
        public void AddNodeTest()
        {
            var root = new TreeNode(4);
            root.AddNode(2);
            root.AddNode(3);
            root.AddNode(1);
            root.AddNode(6);
            root.AddNode(5);
            root.AddNode(7);

            var rootIter = new TreeNode(4);
            rootIter.AddNodeIter(2);
            rootIter.AddNodeIter(3);
            rootIter.AddNodeIter(1);
            rootIter.AddNodeIter(6);
            rootIter.AddNodeIter(5);
            rootIter.AddNodeIter(7);

            var x = 1;
        }

        [TestMethod]
        public void SortedListToBalancedTree_Test()
        {
            var sortedList = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var tree = TreeNode.SortedListToBalancedTree(sortedList);
            var x = 1;
        }

        [TestMethod]
        public void GetDepth_Test()
        {
            var sortedList = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var tree = TreeNode.SortedListToBalancedTree(sortedList);
            var depth = tree.GetDepth(1);

            var rootIter = new TreeNode(4);
            rootIter.AddNodeIter(2);
            rootIter.AddNodeIter(3);
            rootIter.AddNodeIter(1);
            rootIter.AddNodeIter(6);
            rootIter.AddNodeIter(5);
            rootIter.AddNodeIter(7);
            rootIter.AddNodeIter(70);
            var depth1 = rootIter.GetDepth(1);
            var x = 1;
        }

        [TestMethod]
        public void GetAllPaths_Test()
        {
            var sortedList = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var tree = TreeNode.SortedListToBalancedTree(sortedList);
            var allPaths = tree.GetAllPaths();
            var x = 1;
        }

        [TestMethod]
        public void GetAllPathsIter_Test()
        {
            var sortedList = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var tree = TreeNode.SortedListToBalancedTree(sortedList);
            var allPaths = tree.GetAllPathsIter();
            var x = 1;
        }
    }
}