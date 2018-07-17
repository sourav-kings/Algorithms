using System;

namespace Count_Leaf_Nodes_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            /* create a tree */
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            /* get leaf count of the abve tree */
            Console.WriteLine("The leaf count of binary tree is : "
                                 + tree.GetLeafCount());
        }
    }

    public class BinaryTree
    {
        //Root of the Binary Tree
        internal Node root;

        /* Function to get the count of leaf nodes in a binary tree*/
        internal int GetLeafCount()
        {
            return GetLeafCount(root);
        }

        int GetLeafCount(Node node)
        {
            if (node == null)
                return 0;
            if (node.left == null && node.right == null)
                return 1;
            else
                return GetLeafCount(node.left) + GetLeafCount(node.right);
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
 * https://www.geeksforgeeks.org/write-a-c-program-to-get-count-of-leaf-nodes-in-a-binary-tree/ 
 */
