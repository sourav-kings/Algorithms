using System;

namespace DeleteNodes_WhichAre_Greater_On_Right
{
    class Program
    {
        /* Drier program to test above functions */
        public static void Main(string[] args)
        {
            LinkedList llist = new LinkedList();

            /* Constructed Linked List is 12->15->10->11->
               5->6->2->3 */
            llist.Push(3);
            llist.Push(2);
            llist.Push(6);
            llist.Push(5);
            llist.Push(11);
            llist.Push(10);
            llist.Push(15);
            llist.Push(12);

            Console.WriteLine("Given Linked List");
            llist.PrintList();

            llist.DelLesserNodes();

            Console.WriteLine("Modified Linked List");
            llist.PrintList();
        }
    }

    // Java program to delete nodes which have a greater value on 
    // right side
    class LinkedList
    {
        Node head;  // head of list

        /* Linked list Node*/
        class Node
        {
            internal int data;
            internal Node next;
            internal Node(int d) { data = d; next = null; }
        }

        /* Deletes nodes which have a node with greater
           value node on left side */
        internal void DelLesserNodes()
        {
            /* 1.Reverse the linked list */
            ReverseList();

            /* 2) In the reversed list, delete nodes which
               have a node with greater value node on left
               side. Note that head node is never deleted
               because it is the leftmost node.*/
            _delLesserNodes();

            /* 3) Reverse the linked list again to retain
               the original order */
            ReverseList();
        }

        /* Deletes nodes which have greater value node(s)
           on left side */
        void _delLesserNodes()
        {
            Node current = head;

            /* Initialise max */
            Node maxnode = head;
            Node temp;

            while (current != null && current.next != null)
            {
                /* If current is smaller than max, then delete
                   current */
                if (current.next.data < maxnode.data)
                {
                    temp = current.next;
                    current.next = temp.next;
                    temp = null;
                }

                /* If current is greater than max, then update
                   max and move current */
                else
                {
                    current = current.next;
                    maxnode = current;
                }
            }
        }

        /* Utility functions */

        /* Inserts a new Node at front of the list. */
        internal void Push(int new_data)
        {
            /* 1 & 2: Allocate the Node &
                      Put in the data*/
            Node new_node = new Node(new_data);

            /* 3. Make next of new Node as head */
            new_node.next = head;

            /* 4. Move the head to point to new Node */
            head = new_node;
        }

        /* Function to reverse the linked list */
        void ReverseList()
        {
            Node current = head;
            Node prev = null;
            Node next;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

        /* Function to print linked list */
        internal void PrintList()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
    }
}


/*
 * https://www.geeksforgeeks.org/delete-nodes-which-have-a-greater-value-on-right-side/
 * 
 * Delete nodes which have a greater value on right side
 */
