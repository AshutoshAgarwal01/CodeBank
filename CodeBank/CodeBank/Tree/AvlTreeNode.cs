namespace CodeBank.Tree
{
    public class AvlTreeNode
    {
        public int data { get; }
        public AvlTreeNode left;
        public AvlTreeNode right;
        public int height { get; set; }
        public AvlTreeNode(int d)
        {
            data = d;
        }
    }
}
