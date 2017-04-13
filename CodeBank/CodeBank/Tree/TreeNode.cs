using System;

namespace CodeBank.Tree
{
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        internal void AddNode(int data)
        {
            if (data < Data)
            {
                if (Left == null)
                {
                    Left = new TreeNode() { Data = data };
                    return;
                }
                Left.AddNode(data);
            }
            else
            {
                if (Right == null)
                {
                    Right = new TreeNode() { Data = data };
                    return;
                }
                Right.AddNode(data);
            }
        }
    }
}
