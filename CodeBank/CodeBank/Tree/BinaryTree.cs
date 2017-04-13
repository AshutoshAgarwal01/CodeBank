namespace CodeBank.Tree
{
    public class BinaryTree
    {
        public TreeNode Root { get; set; }
        public void AddNode(int data)
        {
            Root.AddNode(data);
        }
    }
}
