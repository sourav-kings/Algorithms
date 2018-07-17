using System;

namespace Minimum_Depth_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("The minimum depth of " +
              "binary tree is : " + tree.MinimumDepth());
        }
    }

    public class BinaryTree
    {
        //Root of the Binary Tree
        internal Node root;

        internal int MinimumDepth()
        {
            return MinimumDepth(root);
        }

        /* Function to calculate the minimum depth of the tree */
        int MinimumDepth(Node root)
        {
            // Corner case. Should never be hit unless the code is
            // called on root = NULL
            if (root == null)
                return 0;

            // Base case : Leaf Node. This accounts for height = 1.
            if (root.left == null && root.right == null)
                return 1;

            // If left subtree is NULL, recur for right subtree
            if (root.left == null)
                return MinimumDepth(root.right) + 1;

            // If right subtree is NULL, recur for left subtree
            if (root.right == null)
                return MinimumDepth(root.left) + 1;

            return Math.Min(MinimumDepth(root.left),
                            MinimumDepth(root.right)) + 1;
        }
    }

    class Node
    {
        internal int data;
        internal Node left, right;
        internal Node(int item)
        {
            data = item;
            left = right = null;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/find-minimum-depth-of-a-binary-tree/
 * 
 * The minimum depth is the number of nodes along the shortest path 
 * from root node down to the nearest leaf node.
 */
