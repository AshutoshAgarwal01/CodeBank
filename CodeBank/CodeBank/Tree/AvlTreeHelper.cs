using System;

namespace CodeBank.Tree
{
    public class AvlTreeHelper
    {
        public static int GetDepth(AvlTreeNode node)
        {
            if (node == null)
                return 0;

            return Math.Max(GetDepth(node.left), GetDepth(node.right)) + 1;
        }

        public static AvlTreeNode InsertNode(AvlTreeNode root, int data)
        {
            if (root == null)
                return new AvlTreeNode(data) { height = 1};

            if (data < root.data)
                root.left = InsertNode(root.left, data);
            else
                root.right = InsertNode(root.right, data);

            if (GetLeftheight(root) - GetRightHeight(root) > 1)
            {
                if (GetLeftheight(root.left) > GetRightHeight(root.left))
                {
                    //LL
                    root = RotateRight(root);
                }
                else
                {
                    //LR
                    root.left = RotateLeft(root.left);
                    root = RotateRight(root);
                }
            }
            else if (GetRightHeight(root) - GetLeftheight(root) > 1)
            {
                if (GetRightHeight(root.right) > GetLeftheight(root.right))
                {
                    //RR
                    root = RotateLeft(root);
                }
                else
                {
                    //RL
                    root.right = RotateRight(root.right);
                    root = RotateLeft(root);
                }
            }
            else
            {
                root.height = Math.Max(GetLeftheight(root), GetRightHeight(root)) + 1;
            }

            return root;
        }

        private static int GetRightHeight(AvlTreeNode root)
        {
            return root.right == null ? 0 : root.right.height;
        }

        private static int GetLeftheight(AvlTreeNode root)
        {
            return root.left == null ? 0 : root.left.height;
        }

        /// <summary>
        /// Insert into AVL tree without using height property of Tree Node.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static AvlTreeNode InsertNodeWithoutHeightProperty(AvlTreeNode root, int data)
        {
            if (root == null)
                return new AvlTreeNode(data);

            if (data < root.data)
                root.left = InsertNodeWithoutHeightProperty(root.left, data);
            else
                root.right = InsertNodeWithoutHeightProperty(root.right, data);

            //return root;
            int leftDepth = root.left == null ? 0 : GetDepth(root.left);
            int rightDepth = root.right == null ? 0 : GetDepth(root.right);
            if (leftDepth - rightDepth > 1)
            {
                leftDepth = root.left.left == null ? 0 : GetDepth(root.left.left);
                rightDepth = root.left.right == null ? 0 : GetDepth(root.left.right);
                if (leftDepth > rightDepth)
                {
                    //LL
                    root = RotateRight(root);
                }
                else
                {
                    //LR
                    root.left = RotateLeft(root.left);
                    root = RotateRight(root);
                }
            }
            else if (rightDepth - leftDepth > 1)
            {
                leftDepth = root.right.left == null ? 0 : GetDepth(root.right.left);
                rightDepth = root.right.right == null ? 0 : GetDepth(root.right.right);
                if (leftDepth > rightDepth)
                {
                    //RL
                    root.right = RotateRight(root.right);
                    root = RotateLeft(root);
                }
                else
                {
                    //RR
                    root = RotateLeft(root);
                }
            }
            return root;
        }

        private static AvlTreeNode RotateLeft(AvlTreeNode root)
        {
            var newRoot = root.right;
            root.right = newRoot.left;
            newRoot.left = root;

            root.height = Math.Min(GetLeftheight(root), GetRightHeight(root)) + 1;
            return newRoot;
        }

        private static AvlTreeNode RotateRight(AvlTreeNode root)
        {
            var newRoot = root.left;
            root.left = newRoot.right;
            newRoot.right = root;

            root.height = Math.Min(GetLeftheight(root), GetRightHeight(root)) + 1;
            return newRoot;
        }
    }
}
