using System;

namespace Sorted_Order_Printing_Of_Array_ThatRepresents_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 2, 5, 1, 3 };

            PrintSorted(arr, 0, arr.Length - 1);
        }

        static void PrintSorted(int[] arr, int start,
                                                int end)
        {
            if (start > end)
                return;

            // print left subtree
            PrintSorted(arr, start * 2 + 1, end);

            // print root
            Console.Write(arr[start] + " ");

            // print right subtree
            PrintSorted(arr, start * 2 + 2, end);
        }
    }
}
/*
 * https://www.geeksforgeeks.org/sorted-order-printing-of-an-array-that-represents-a-bst/
 * 
 * Inorder traversal of BST prints it in ascending order. 
 * The only trick is to modify recursion termination condition in standard Inorder Tree Traversal.
 */
