using System;

namespace Ancestors_GivenNode_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {

            BinaryTree tree = new BinaryTree();

            /* Construct the following binary tree
                      1
                    /   \
                   2     3
                  /  \
                 4    5
                /
               7
            */
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.left.left.left = new Node(7);

            tree.target = 7;
            tree.PrintAncestors(tree.root);
        }
    }

    /* A binary tree node has data, pointer to left child
   and a pointer to right child */
    class Node
    {
        internal int data;
        internal Node left, right, nextRight;

        internal Node(int item)
        {
            data = item;
            left = right = nextRight = null;
        }
    }

    class BinaryTree
    {
        internal Node root;
        internal int target;

        /* If target is present in tree, then prints the ancestors
           and returns true, otherwise returns false. */
        internal bool PrintAncestors(Node node)
        {
            /* base cases */
            if (node == null)
                return false;

            if (node.data == target)
                return true;

            /* If target is present in either left or right subtree 
               of this node, then print this node */
            if (PrintAncestors(node.left)
                    || PrintAncestors(node.right))
            {
                Console.WriteLine(node.data + " ");
                return true;
            }

            /* Else return false */
            return false;
        }
    }
}

/*
 * https://www.geeksforgeeks.org/print-ancestors-of-a-given-node-in-binary-tree/
 * 
 * Time Complexity: O(n) where n is the number of nodes in the given Binary Tree.
 */
