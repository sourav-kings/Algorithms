using System;

namespace Nodes_That_Dont_Have_Sibling_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            /* Let us construct the tree shown in above diagram */
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.right = new Node(4);
            tree.root.right.left = new Node(5);
            tree.root.right.left.right = new Node(6);
            tree.PrintSingles(tree.root);
        }
    }

    class BinaryTree
    {
        internal Node root;

        // Function to print all non-root nodes that don't have a sibling
        internal void PrintSingles(Node node)
        {
            // Base case
            if (node == null)
                return;

            // If this is an internal node, recur for left
            // and right subtrees
            if (node.left != null && node.right != null)
            {
                PrintSingles(node.left);
                PrintSingles(node.right);
            }

            // If left child is NULL and right is not, print right child
            // and recur for right child
            else if (node.right != null)
            {
                Console.WriteLine(node.right.data + " ");
                PrintSingles(node.right);
            }

            // If right child is NULL and left is not, print left child
            // and recur for left child
            else if (node.left != null)
            {
                Console.WriteLine(node.left.data + " ");
                PrintSingles(node.left);
            }
        }
    }


    // A binary tree node
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
 * https://www.geeksforgeeks.org/print-nodes-dont-sibling-binary-tree/
 */
