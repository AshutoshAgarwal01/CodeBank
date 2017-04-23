using System;
using System.Collections.Generic;

namespace CodeBank.Tree
{
    public class TreeNode
    {
        public TreeNode(int v)
        {
            this.data = v;
        }

        private int data;
        private TreeNode left;
        private TreeNode right;

        public void AddNode(int data)
        {
            if (data < this.data)
            {
                if (left == null)
                {
                    left = new TreeNode(data);
                    return;
                }
                left.AddNode(data);
            }
            else
            {
                if (right == null)
                {
                    right = new TreeNode(data);
                    return;
                }
                right.AddNode(data);
            }
        }

        public void AddNodeIter(int data)
        {
            TreeNode current = this;
            while (current != null)
            {
                if (data < current.data)
                {
                    if (current.left == null)
                    {
                        current.left = new TreeNode(data);
                        break;
                    }
                    current = current.left;
                }
                else
                {
                    if (current.right == null)
                    {
                        current.right = new TreeNode(data);
                        break;
                    }
                    current = current.right;
                }
            }
        }

        public static TreeNode SortedListToBalancedTree(List<int> sortedList)
        {
            if (sortedList == null || sortedList.Count == 0)
            {
                return null;
            }

            return GetTree(0, sortedList.Count - 1, sortedList);
        }

        /// <summary>
        /// Get depth of a node.
        /// </summary>
        /// <returns></returns>
        public int GetDepth()
        {
            if (IsLeaf())
                return 1;

            int leftDepth = left == null ? 0 : left.GetDepth();
            int rightDepth = right == null ? 0 : right.GetDepth();
            return Math.Max(leftDepth, rightDepth) + 1;
        }

        public int GetDepth(int d)
        {
            int leftDepth = (left == null) ? d : left.GetDepth(d + 1);
            int rightDepth = (right == null) ? d : right.GetDepth(d + 1);
            return Math.Max(leftDepth, rightDepth);
        }

        private static TreeNode GetTree(int begin, int end, List<int> sortedList)
        {
            if (begin > end)
            {
                return null;
            }
            var midIndex = (begin + end) / 2;
            var root = new TreeNode(sortedList[midIndex]);

            root.left = GetTree(begin, midIndex - 1, sortedList);
            root.right = GetTree(midIndex + 1, end, sortedList);
            return root;
        }

        public void InOrderTraversal()
        {
            //Left, root, right
            if (left != null)
                left.InOrderTraversal();

            Console.Write(data + ", ");

            if (right != null)
                right.InOrderTraversal();
        }

        public void PreOrderTraversal()
        {
            //root, left, right
            Console.Write(data + ", ");

            if (left != null)
                left.PreOrderTraversal();

            if (right != null)
                right.PreOrderTraversal();
        }

        public void PostOrderTraversal()
        {
            //Left, right, root
            if (left != null)
                left.PostOrderTraversal();

            if (right != null)
                right.PostOrderTraversal();

            Console.Write(data + ", ");
        }

        public void LevelOrderTraversal()
        {
            //traverse by level...left to right
            var q = new Queue<TreeNode>();
            q.Enqueue(this);
            LevelOrderTraversal(q);
        }

        public List<List<int>> GetAllPaths()
        {
            var allPaths = new List<List<int>>();
            var leftPaths = (left == null) ? new List<List<int>>() : left.GetAllPaths();
            var rightPaths = (right == null) ? new List<List<int>>() : right.GetAllPaths();

            if (leftPaths.Count == 0 && rightPaths.Count == 0)
            {
                return new List<List<int>>() { new List<int>() { data } };
            }

            foreach (var p in leftPaths)
            {
                var newPath = new List<int>() { data };
                newPath.AddRange(p);
                allPaths.Add(newPath);
            }

            foreach (var p in rightPaths)
            {
                var newPath = new List<int>() { data };
                newPath.AddRange(p);
                allPaths.Add(newPath);
            }
            return allPaths;
        }

        public List<List<int>> GetAllPathsIter()
        {
            var q = new Queue<TreeNode>();
            q.Enqueue(this);

            var pathQueue = new Queue<List<int>>();
            pathQueue.Enqueue(new List<int>() { data });

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (!current.IsLeaf())
                {
                    var path = pathQueue.Dequeue();
                    if (current.left != null)
                    {
                        var newPath = new List<int>();
                        newPath.AddRange(path);
                        newPath.Add(current.left.data);
                        pathQueue.Enqueue(newPath);
                        q.Enqueue(current.left);
                    }

                    if (current.right != null)
                    {
                        var newPath = new List<int>();
                        newPath.AddRange(path);
                        newPath.Add(current.right.data);
                        pathQueue.Enqueue(newPath);
                        q.Enqueue(current.right);
                    }
                }
            }

            var result = new List<List<int>>();
            while (pathQueue.Count > 0)
            {
                result.Add(pathQueue.Dequeue());
            }
            return result;
        }

        private bool IsLeaf()
        {
            return left == null && right == null;
        }

        private void LevelOrderTraversal(Queue<TreeNode> q)
        {
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                Console.Write(current.data + ", ");
                if (current.left != null)
                    q.Enqueue(current.left);
                if (current.right != null)
                    q.Enqueue(current.right);
            }
        }
    }
}
