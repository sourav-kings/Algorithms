﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapNodes_Without_SwappingData_LinkedList
{
    class Program
    {
        static Node head;
        static void Main(string[] args)
        {
            /* The constructed linked list is:
            1->2->3->4->5->6->7 */
            Push(7);
            Push(6);
            Push(5);
            Push(4);
            Push(3);
            Push(2);
            Push(1);

            Console.Write("\n Linked list before calling swapNodes() ");
            PrintList();

            SwapNodes(2, 5);

            Console.Write("\n Linked list after calling swapNodes() ");
            PrintList();
        }

        /* Function to swap Nodes x and y in linked list by
   changing links */
        static void SwapNodes(int x, int y)
        {
            // Nothing to do if x and y are same
            if (x == y) return;

            // Search for x (keep track of prevX and CurrX)
            Node prevX = null, currX = head;
            while (currX != null && currX.data != x)
            {
                prevX = currX;
                currX = currX.next;
            }

            // Search for y (keep track of prevY and currY)
            Node prevY = null, currY = head;
            while (currY != null && currY.data != y)
            {
                prevY = currY;
                currY = currY.next;
            }

            // If either x or y is not present, nothing to do
            if (currX == null || currY == null)
                return;

            // If x is not head of linked list
            if (prevX != null)
                prevX.next = currY;
            else //make y the new head
                head = currY;

            // If y is not head of linked list
            if (prevY != null)
                prevY.next = currX;
            else // make x the new head
                head = currX;

            // Swap next pointers
            Node temp = currX.next;
            currX.next = currY.next;
            currY.next = temp;
        }

        /* Function to add Node at beginning of list. */
        static void Push(int new_data)
        {
            /* 1. alloc the Node and put the data */
            Node new_Node = new Node(new_data);

            /* 2. Make next of new Node as head */
            new_Node.next = head;

            /* 3. Move the head to point to new Node */
            head = new_Node;
        }

        /* This function prints contents of linked list starting
           from the given Node */
        static void PrintList()
        {
            Node tNode = head;
            while (tNode != null)
            {
                Console.Write(tNode.data + " ");
                tNode = tNode.next;
            }
        }
    }

    class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }
}

//http://www.geeksforgeeks.org/swap-nodes-in-a-linked-list-without-swapping-data/