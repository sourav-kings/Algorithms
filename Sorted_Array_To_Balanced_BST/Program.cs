using System;

namespace Sorted_Array_To_Balanced_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int n = arr.Length;
            tree.root = tree.SortedArrayToBST(arr, 0, n - 1);
            Console.WriteLine("Preorder traversal of constructed BST");
            tree.PreOrder(tree.root);
        }
    }


    class BinaryTree
    {

        internal Node root;

        /* A function that constructs Balanced Binary Search Tree 
         from a sorted array */
        internal Node SortedArrayToBST(int[] arr, int start, int end)
        {

            /* Base Case */
            if (start > end)
                return null;

            /* Get the middle element and make it root */
            int mid = (start + end) / 2;
            Node node = new Node(arr[mid]);

            /* Recursively construct the left subtree and make it
             left child of root */
            node.left = SortedArrayToBST(arr, start, mid - 1);

            /* Recursively construct the right subtree and make it
             right child of root */
            node.right = SortedArrayToBST(arr, mid + 1, end);

            return node;
        }

        /* A utility function to print preorder traversal of BST */
        internal void PreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            Console.Write(node.data + " ");
            PreOrder(node.left);
            PreOrder(node.right);
        }

    }

    // A binary tree node
    internal class Node
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
 * https://www.geeksforgeeks.org/sorted-array-to-balanced-bst/
 */
