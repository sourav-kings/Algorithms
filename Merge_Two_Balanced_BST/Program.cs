using System;
using System.Collections.Generic;
using System.Linq;

namespace Merge_Two_Balanced_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 3, 5, 7, 9 };
            Node node1 = ArrayToBST(arr1, 0, arr1.Length - 1);
            PrintBST(node1);
            Console.WriteLine();

            int[] arr2 = { 2, 4, 6, 8, 15 };
            Node node2 = ArrayToBST(arr2, 0, arr2.Length - 1);

            PrintBST(node2);
            Console.WriteLine();


            Node nodeResult = Merge(node1, node2);

            PrintBST(nodeResult);
            Console.WriteLine();
        }

        static Node Merge(Node node1, Node node2)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            CreateList(node1, list1);
            CreateList(node2, list2);
            int[] arr = new int[list1.Count() + list2.Count()];
            Merge(list1, list2, arr);
            return ArrayToBST(arr, 0, arr.Length - 1);
        }

        static void CreateList(Node root, List<int> list)
        {
            if (root == null)
                return;

            CreateList(root.left, list);
            list.Add(root.data);
            CreateList(root.right, list);
        }

        static void Merge(List<int> list1, List<int> list2, int[] arr)
        {
            int i = 0;
            while (list1.Any() && list2.Any())
            {
                if (list1.ElementAt(0) < list2.ElementAt(0))
                {
                    arr[i++] = list1.ElementAt(0);
                    list1.RemoveAt(0);
                }
                else
                {
                    arr[i++] = list2.ElementAt(0);
                    list2.RemoveAt(0);
                }
            }
            
            while (list1.Any())
            {
                arr[i++] = list1.ElementAt(0);
                list1.RemoveAt(0);
            }

            while (list2.Any())
            {
                arr[i++] = list2.ElementAt(0);
                list2.RemoveAt(0);
            }
        }

        static Node ArrayToBST(int[] arr, int low, int high)
        {
            if (high < low)
                return null;

            if (arr == null || arr.Length == 0)
                return null;

            int mid = low + (high - low) / 2;
            Node node = new Node(arr[mid]);
            node.left = ArrayToBST(arr, low, mid - 1);
            node.right = ArrayToBST(arr, mid + 1, high);

            return node;
        }


        static void PrintBST(Node node)
        {
            if (node == null)
                return;

            // pre-order

            Console.Write(node.data + " ");

            PrintBST(node.left);
            PrintBST(node.right);
        }
    }

    class Node
    {
        public Node left;
        public Node right;
        public int data;

        public Node(int d)
        {
            data = d;
        }
    }
}
/*can also be solved by:-
 * conversion of binary tree to Doubly linklist and then merge two DLLs and the convert DLL to Binary tree*/
//http://code.geeksforgeeks.org/hoZVLv

//http://www.geeksforgeeks.org/merge-two-balanced-binary-search-trees/



//Average Difficulty : 3.6/5.0
//Based on 44 vote(s)

    /*
     * ALGO::
     * 
     * 0. 
     * 1. Convert two given arrays into BST. (if not already provided). 
     * 2. Convert both BST nodes into two seperate List using InOrder Traversal.
     * 3. Call function with these two lists and a empty result array.
     * 4. While loop until both lists item exists:
     *          Compare 1st item of both list. Add the smaller one to result array and remove the same from list.
     *    While if list1 items still exist.
     *          Add 1st item in the result and remove the same from 1st list.
     *    Repeat for 2nd list. 
     */