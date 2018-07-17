using System;

namespace Alternating_Split_LinkedList
{
    class Program
    {

        static Node head, a, b;
        static void Main(string[] args)
        {
            Push(5);
            Push(4);
            Push(3);
            Push(2);
            Push(1);
            Push(0);

            Console.WriteLine("\n Original linked List:  ");
            PrintList(head);

            /* Remove duplicates from linked list */
            AlternatingSplit(head, ref a, ref b);

            Console.WriteLine("\n Resultant Linked List 'a' ");
            PrintList(a);

            Console.WriteLine("\n Resultant Linked List 'b' ");
            PrintList(b);
        }

        static void AlternatingSplit(Node head, ref Node aRef, ref Node bRef)
        {
            Node aDummy = new Node(-1);
            Node aTail = aDummy; /* points to the last node in 'a' */
            Node bDummy = new Node(-1);
            Node bTail = bDummy; /* points to the last node in 'b' */
            Node current = head;
            aDummy.next = null;
            bDummy.next = null;
            while (current != null)
            {
                MoveNode(ref aTail.next, ref current); /* add at 'a' tail */
                aTail = aTail.next; /* advance the 'a' tail */
                if (current != null)
                {
                    MoveNode(ref bTail.next, ref current);
                    bTail = bTail.next;
                }
            }
            aRef = aDummy.next;
            bRef = bDummy.next;
        }


        /* Take the node from the front of the source, and move it to the front of the dest.
           It is an error to call this with the source list empty. 
    
           Before calling MoveNode():
           source == {1, 2, 3}   
           dest == {1, 2, 3}
       
           After calling MoveNode():
           source == {2, 3}      
           dest == {1, 1, 2, 3}      
        */
        static void MoveNode(ref Node destRef, ref Node sourceRef)
        {
            /* the front source node  */
            Node newNode = sourceRef;
            if (newNode != null)
            {
                /* Advance the source pointer */
                sourceRef = newNode.next;

                /* Link the old dest off the new node */
                newNode.next = destRef;

                /* Move dest to point to the new node */
                destRef = newNode;
            }
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

        /* Function to print nodes in a given linked list */
        static void PrintList(Node node)
        {
            while (node != null)
            {
                Console.Write(node.data + "  ");
                node = node.next;
            }
        }
    }

    /* Link list node */
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
}

/*
 * https://www.geeksforgeeks.org/alternating-split-of-a-given-singly-linked-list/
 * 
 */
