using System;

namespace RootToLeaf_Paths_One_Per_Line
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

            /* Print all root-to-leaf paths of the input tree */
            tree.PrintPaths(tree.root);
        }
    }

    class BinaryTree
    {
        internal Node root;

        /* Given a binary tree, print out all of its root-to-leaf
           paths, one per line. Uses a recursive helper to do the work.*/
        internal void PrintPaths(Node node)
        {
            int[] path = new int[1000];
            PrintPathsRecur(node, path, 0);
        }

        /* Recursive helper function -- given a node, and an array containing
           the path from the root node up to but not including this node,
           print out all the root-leaf paths. */
        void PrintPathsRecur(Node node, int[] path, int pathLen)
        {
            if (node == null)
                return;

            /* append this node to the path array */
            path[pathLen] = node.data;
            pathLen++;

            /* it's a leaf, so print the path that led to here */
            if (node.left == null && node.right == null)
                PrintArray(path, pathLen);
            else
            {
                /* otherwise try both subtrees */
                PrintPathsRecur(node.left, path, pathLen);
                PrintPathsRecur(node.right, path, pathLen);
            }
        }

        /* Utility that prints out an array on a line */
        void PrintArray(int[] ints, int len)
        {
            int i;
            for (i = 0; i < len; i++)
                Console.Write(ints[i] + " ");
            Console.WriteLine("");
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


//https://www.geeksforgeeks.org/given-a-binary-tree-print-out-all-of-its-root-to-leaf-paths-one-per-line/