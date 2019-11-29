using System;

namespace Keys_In_GivenRange_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            int k1 = 10, k2 = 25;
            tree.root = new Node(20);
            tree.root.left = new Node(8);
            tree.root.right = new Node(22);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(12);

            tree.Print(tree.root, k1, k2);
        }
    }


    class BinaryTree
    {
        internal Node root;

        /* The functions prints all the keys which in the given range [k1..k2].
         The function assumes than k1 < k2 */
        internal void Print(Node node, int k1, int k2)
        {
            /* base case */
            if (node == null)
                return;

            /* Since the desired o/p is sorted, recurse for left subtree first
             If root->data is greater than k1, then only we can get o/p keys
             in left subtree */
            if (k1 < node.data)
                Print(node.left, k1, k2);

            /* if root's data lies in range, then prints root's data */
            if (k1 <= node.data && k2 >= node.data)
                Console.WriteLine(node.data + " ");

            /* If root->data is smaller than k2, then only we can get o/p keys
             in right subtree */
            if (k2 > node.data)
                Print(node.right, k1, k2);
        }
    }

    class Node
    {
        internal int data;
        internal Node left, right;

        internal Node(int d)
        {
            data = d;
            left = right = null;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/print-bst-keys-in-the-given-range/
 * (2.5 / 150)
 */
