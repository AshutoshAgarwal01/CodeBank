using CodeBank.Tree;
using System;
using System.Collections.Generic;

namespace CodeBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = TreeNode.SortedListToBalancedTree(new List<int>() { 1, 2, 3, 4, 5, 6, 7 });
            Console.WriteLine("In order: ");
            tree.InOrderTraversal();
            Console.WriteLine();

            Console.WriteLine("Pre order: ");
            tree.PreOrderTraversal();
            Console.WriteLine();

            Console.WriteLine("Post order: ");
            tree.PostOrderTraversal();
            Console.WriteLine();

            Console.WriteLine("Level order: ");
            tree.LevelOrderTraversal();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
