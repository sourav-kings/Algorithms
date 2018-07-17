using System;

namespace Flattening_LinkedList
{
    class Program
    {
        static Node head;  // head of list 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void Push(int new_data)
        {
            /* allocate Node */
            Node new_node = new Node(new_data);

            /* link the old list off the new Node */
            new_node.next = head;

            /* move the head to point to the new Node */
            head = new_node;
        }
    }

    class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }
}


/*
 * https://www.geeksforgeeks.org/flattening-a-linked-list/
 * 
 * 
 */
