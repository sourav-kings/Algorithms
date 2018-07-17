using System;

namespace All_Root_To_Leaf_Paths
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(10);
            tree.root.left = new Node(8);
            tree.root.right = new Node(2);
            tree.root.left.left = new Node(3);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(2);

            /* Let us test the built tree by printing Insorder traversal */
            tree.PrintPaths(tree.root);
        }
    }

    // Java program to print all the node to leaf path

    class BinaryTree
    {
        internal Node root;

        /*Given a binary tree, print out all of its root-to-leaf
          paths, one per line. Uses a recursive helper to do 
          the work.*/
        internal void PrintPaths(Node node)
        {
            int[] path = new int[1000];
            PrintPathsRecur(node, path, 0);
        }

        /* Recursive helper function -- given a node, and an array
           containing the path from the root node up to but not 
           including this node, print out all the root-leaf paths.*/
        void PrintPathsRecur(Node node, int[] path, int pathLen)
        {
            if (node == null)
                return;

            /* append this node to the path array */
            path[pathLen] = node.data;
            pathLen++;

            /* it's a leaf, so print the path that led to here  */
            if (node.left == null && node.right == null)
                PrintArray(path, pathLen);
            else
            {
                /* otherwise try both subtrees */
                PrintPathsRecur(node.left, path, pathLen);
                PrintPathsRecur(node.right, path, pathLen);
            }
        }

        /* Utility function that prints out an array on a line. */
        void PrintArray(int[] ints, int len)
        {
            int i;
            for (i = 0; i < len; i++)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine("");
        }
    }


    /* A binary tree node has data, pointer to left child
       and a pointer to right child */
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
 * https://www.geeksforgeeks.org/given-a-binary-tree-print-all-root-to-leaf-paths/
 * 
 * Time Complexity: O(n*n) where n is number of nodes.
 */
