using System;

namespace Segregate_EvenOdd_Nodes_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList llist = new LinkedList();
            llist.Push(11);
            llist.Push(10);
            llist.Push(9);
            llist.Push(6);
            llist.Push(4);
            llist.Push(1);
            llist.Push(0);
            Console.WriteLine("Origional Linked List");
            llist.PrintList();

            //llist.SegregateEvenOdd();
            llist.SegregateEvenOdd_Faster();

            Console.WriteLine("Modified Linked List");
            llist.PrintList();
        }
    }

    // Java program to segregate even and odd nodes in a
    // Linked List
    class LinkedList
    {
        Node head;  // head of list

        /* Linked list Node*/
        class Node
        {
            internal int data;
            internal Node next;
            internal Node(int d)
            {
                data = d;
                next = null;
            }
        }

        internal void SegregateEvenOdd()
        {
            Node end = head;
            Node prev = null;
            Node curr = head;

            /* Get pointer to last Node */
            while (end.next != null)
                end = end.next;

            Node new_end = end;

            // Consider all odd nodes before getting first even node
            while (curr.data % 2 != 0 && curr != end)
            {
                new_end.next = curr;
                curr = curr.next;
                new_end.next.next = null;
                new_end = new_end.next;
            }

            // do following steps only if there is an even node
            if (curr.data % 2 == 0)
            {
                head = curr;

                // now curr points to first even node
                while (curr != end)
                {
                    if (curr.data % 2 == 0)
                    {
                        prev = curr;
                        curr = curr.next;
                    }
                    else
                    {
                        /* Break the link between prev and curr*/
                        prev.next = curr.next;

                        /* Make next of curr as null */
                        curr.next = null;

                        /*Move curr to end */
                        new_end.next = curr;

                        /*Make curr as new end of list */
                        new_end = curr;

                        /*Update curr pointer */
                        curr = prev.next;
                    }
                }
            }

            /* We have to set prev before executing rest of this code */
            else prev = curr;

            if (new_end != end && end.data % 2 != 0)
            {
                prev.next = end.next;
                end.next = null;
                new_end.next = end;
            }
        }

        internal void SegregateEvenOdd_Faster()
        {
            Node eStart = null, eEnd = null, oStart = null, oEnd = null;
            Node curr = head;

            while (curr != null)
            {
                int element = curr.data;

                if (element % 2 == 0)
                {
                    if (eStart == null){
                        eStart = curr;
                        eEnd = eStart;
                    }
                    else{
                        eEnd.next = curr;
                        eEnd = eEnd.next;
                    }

                }
                else
                {
                    if (oStart == null){
                        oStart = curr;
                        oEnd = oStart;
                    }
                    else{
                        oEnd.next = curr;
                        oEnd = oEnd.next;
                    }
                }
                // Move head pointer one step in forward direction
                curr = curr.next;
            }


            if (oStart == null || eStart == null)
                return;

            eEnd.next = oStart;
            oEnd.next = null;
            head = eStart;
        }

        /*  Given a reference (pointer to pointer) to the head
            of a list and an int, Push a new node on the front
            of the list. */
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

        // Utility function to print a linked list
        internal void PrintList()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + " -> ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
    }
}

/*https://www.geeksforgeeks.org/segregate-even-and-odd-elements-in-a-linked-list/*/
