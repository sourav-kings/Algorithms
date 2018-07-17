using System;

namespace Sorted_DoublyLinkedList_To_Balanced_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList llist = new LinkedList();

            /* Let us create a sorted linked list to test the functions
               Created linked list will be 7->6->5->4->3->2->1 */
            llist.Push(7);
            llist.Push(6);
            llist.Push(5);
            llist.Push(4);
            llist.Push(3);
            llist.Push(2);
            llist.Push(1);

            Console.WriteLine("Given Linked List ");
            llist.PrintList(head);

            /* Convert List to BST */
            TNode root = llist.SortedListToBST();
            Console.WriteLine("");
            Console.WriteLine("Pre-Order Traversal of constructed BST ");
            llist.PreOrder(root);
        }
    }


    class LinkedList
    {

        /* head node of link list */
        internal static LNode head;

        /* Link list Node */
        internal class LNode
        {
            internal int data;
            internal LNode next, prev;

            internal LNode(int d)
            {
                data = d;
                next = prev = null;
            }
        }

        /* A Binary Tree Node */
        internal class TNode
        {
            internal int data;
            internal TNode left, right;

            internal TNode(int d)
            {
                data = d;
                left = right = null;
            }
        }

        /* This function counts the number of nodes in Linked List
           and then calls sortedListToBSTRecur() to construct BST */
        internal TNode SortedListToBST()
        {
            /*Count the number of nodes in Linked List */
            int n = CountNodes(head);

            /* Construct BST */
            return SortedListToBSTRecur(n);
        }

        /* The main function that constructs balanced BST and
           returns root of it.
           n  --> No. of nodes in the Doubly Linked List */
        TNode SortedListToBSTRecur(int n)
        {
            /* Base Case */
            if (n <= 0)
                return null;

            /* Recursively construct the left subtree */
            TNode left = SortedListToBSTRecur(n / 2);

            /* head_ref now refers to middle node, 
               make middle node as root of BST*/
            TNode root = new TNode(head.data);

            // Set pointer to left subtree
            root.left = left;

            /* Change head pointer of Linked List for parent 
               recursive calls */
            head = head.next;

            /* Recursively construct the right subtree and link it 
               with root. The number of nodes in right subtree  is 
               total nodes - nodes in left subtree - 1 (for root) */
            root.right = SortedListToBSTRecur(n - n / 2 - 1);

            return root;
        }

        /* UTILITY FUNCTIONS */
        /* A utility function that returns count of nodes in a 
           given Linked List */
        int CountNodes(LNode head)
        {
            int count = 0;
            LNode temp = head;
            while (temp != null)
            {
                temp = temp.next;
                count++;
            }
            return count;
        }

        /* Function to insert a node at the beginging of 
           the Doubly Linked List */
        internal void Push(int new_data)
        {
            /* allocate node */
            LNode new_node = new LNode(new_data);

            /* since we are adding at the begining,
               prev is always NULL */
            new_node.prev = null;

            /* link the old list off the new node */
            new_node.next = head;

            /* change prev of head node to new node */
            if (head != null)
                head.prev = new_node;

            /* move the head to point to the new node */
            head = new_node;
        }

        /* Function to print nodes in a given linked list */
        internal void PrintList(LNode node)
        {
            while (node != null)
            {
                Console.WriteLine(node.data + " ");
                node = node.next;
            }
        }

        /* A utility function to print preorder traversal of BST */
        internal void PreOrder(TNode node)
        {
            if (node == null)
                return;
            Console.WriteLine(node.data + " ");
            PreOrder(node.left);
            PreOrder(node.right);
        }
    }
}
/*
 * https://www.geeksforgeeks.org/in-place-conversion-of-sorted-dll-to-balanced-bst/
 * 
 * Time Complexity: O(n)
 * 
 * Average Difficulty : 3.9/5.0
 * Based on 124 vote(s)
 */
