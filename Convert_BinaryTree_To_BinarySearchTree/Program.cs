using System;

namespace Convert_BinaryTree_To_BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;

            /* Constructing tree given in the above figure
                  10
                 /  \
                30   15
               /      \
              20       5   */
            root = new Node(10);
            root.left = new Node(30);
            root.right = new Node(15);
            root.left.left = new Node(20);
            root.right.right = new Node(5);

            // convert Binary Tree to BST
            BinaryTreeToBST(root);

            Console.WriteLine("Following is Inorder Traversal of the converted BST: \n");
            PrintInorder(root);
        }


        // This function converts a given Binary Tree to BST
        static void BinaryTreeToBST(Node root)
        {
            // base case: tree is empty
            if (root == null)
                return;

            /* Count the number of nodes in Binary Tree so that
               we know the size of temporary array to be created */
            int n = CountNodes(root);

            // Create a temp array arr[] and store inorder traversal of tree in arr[]
            int[] arr = new int[n];
            int i = 0;
            StoreInorder(root, arr, ref i);

            // Sort the array using library function for quick sort
            Array.Sort(arr);

            // Copy array elements back to Binary Tree
            i = 0;
            ArrayToBST(arr, root, ref i);
        }

        /* A helper function that stores inorder traversal of a tree rooted
          with Node*/
        static void StoreInorder(Node node, int[] inorder, ref int index_ptr)
        {
            // Base Case
            if (node == null)
                return;

            /* first store the left subtree */
            StoreInorder(node.left, inorder, ref index_ptr);

            /* Copy the root's data */
            inorder[index_ptr++] = node.data;
            //(index_ptr)++;  // increase index for next entry

            /* finally store the right subtree */
            StoreInorder(node.right, inorder, ref index_ptr);
        }

        /* A helper function to count nodes in a Binary Tree */
        static int CountNodes(Node root)
        {
            if (root == null)
                return 0;
            return CountNodes(root.left) +
                   CountNodes(root.right) + 1;
        }

        /* A helper function that copies contents of arr[] to Binary Tree. 
           This functon basically does Inorder traversal of Binary Tree and 
           one by one copy arr[] elements to Binary Tree nodes */
        static void ArrayToBST(int[] arr, Node root, ref int index_ptr)
        {
            // Base Case
            if (root == null)
                return;

            /* first update the left subtree */
            ArrayToBST(arr, root.left, ref index_ptr);

            /* Now update root's data and increment index */
            root.data = arr[index_ptr];
            (index_ptr)++;

            /* finally update the right subtree */
            ArrayToBST(arr, root.right, ref index_ptr);
        }


        /* Utility function to print inorder traversal of Binary Tree */
        static void PrintInorder(Node node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            PrintInorder(node.left);

            /* then print the data of node */
            Console.Write(node.data + " ");

            /* now recur on right child */
            PrintInorder(node.right);
        }
    }

    class Node
    {
        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }
}

/*
 * https://www.geeksforgeeks.org/binary-tree-to-binary-search-tree-conversion/
 * 
 * Following is a 3 step solution for converting Binary tree to Binary Search Tree.
1) Create a temp array arr[] that stores inorder traversal of the tree. 
    This step takes O(n) time.
2) Sort the temp array arr[]. Time complexity of this step depends upon 
    the sorting algorithm. In the following implementation, 
    Quick Sort is used which takes (n^2) time. This can be done in O(nLogn) time 
    using Heap Sort or Merge Sort.
3) Again do inorder traversal of tree and 
    copy array elements to tree nodes one by one. This step takes O(n) time.
 */
