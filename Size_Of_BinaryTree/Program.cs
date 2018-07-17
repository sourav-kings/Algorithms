using System;

namespace Size_Of_BinaryTree
{
    class Program
    {
        public static void Main(String args[])
        {
            /* creating a binary tree and entering the nodes */
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("The size of binary tree is : "
                                + tree.Size());
        }
    }

    /* Class to find size of Binary Tree */
    class BinaryTree
    {
        internal Node root;

        /* Given a binary tree. Print its nodes in level order
           using array for implementing queue */
        internal int Size()
        {
            return Size(root);
        }

        /* computes number of nodes in tree */
        int Size(Node node)
        {
            if (node == null)
                return 0;
            else
                return (Size(node.left) + 1 + Size(node.right));
        }


    }

    /* Class containing left and right child of current
   node and key value*/
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
//https://www.geeksforgeeks.org/write-a-c-program-to-calculate-size-of-a-tree/
/*
 * Time & Space Complexities: Since this program is similar to traversal of tree, 
 * time and space complexities will be same as Tree traversal 
 * (Please see "Tree Traversal" post for details)
 */
