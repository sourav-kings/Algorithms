using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_LinkedList
{
    class Program
    {
        static Node head;
        static void Main(string[] args)
        {
            head = new Node(1);
            head.next = new Node(2);
            head.next.next = new Node(3);
            head.next.next.next = new Node(4);
            head.next.next.next.next = new Node(5);

            Console.WriteLine("Given Linked list");
            printList(head);
            head = reverse2();
            //head = reverse3_testWorking(head);
            Console.WriteLine("");
            Console.WriteLine("Reversed linked list ");
            printList(head);
        }

        /* Function to reverse the linked list 
         * 
         * Iterative Method::
         * In loop, 
         *  change next to prev, 
         *  prev to current and 
         *  current to next.
         
             */

        static public Node reverse(Node node)
        {
            Node current = node, prev = null, next = null;

            while (current != null)
            {
                next = current.next;

                current.next = prev;
                prev = current;

                current = next;
            }
            return prev;
        }


        /*
         * 1 --> 2 --> 3 --> 4 --> 5
         * 
         * For each current node::
         *      Set --> next = prev_value. 
         *      Set --> prev_value = curr node.
         * Repeat for next node.
         */
        static public Node reverse2()
        {
            Node curr = head, prev = null, next = null;

            while (curr != null)
            {
                next = curr.next;

                /****************/
                curr.next = prev;
                prev = curr;
                /****************/

                curr = next;
            }

            return prev;

        }


        static public Node reverse3_testWorking(Node node)
        {
            Node next;
            Node prev = node, head = node;
            Node curr = node.next;
            while (curr != null)
            {
                next = curr.next;

                prev.next = next;
                curr.next = head;
                head = curr;

                curr = next;
            }

            return head;
        }

        static public Node reverseInGroup_test(Node node)
        {
            Node next;
            Node prev = node, head = node;
            Node curr = node.next;
            while (curr != null)
            {
                next = curr.next;

                prev.next = next;
                curr.next = head;
                head = curr;

                curr = next;
            }

            return head;
        }

        // prints content of double linked list
        static public void printList(Node node)
        {
            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
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


//http://www.geeksforgeeks.org/write-a-function-to-reverse-the-nodes-of-a-linked-list/

//Average Difficulty : 2.7/5.0
//Based on 274 vote(s)

/*
 * Iterative Method
Iterate through the linked list. 
    In loop, change next to prev, prev to current and current to next.
 */