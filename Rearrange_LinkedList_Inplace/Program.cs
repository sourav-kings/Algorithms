using System;

namespace Rearrange_LinkedList_Inplace
{
    class Program
    {
        static Node head;
        static Node last;

        static void Main(string[] args)
        {
            //              Output:
            //              1-> 2-> 3-> 4-> 5
            //              1-> 5-> 2-> 4-> 3
            Push(1);
            Push(2);
            Push(3);
            Push(4);
            Push(5);

            Display(head);

            Rearrange(head);

            Console.WriteLine("");
            Display(head);
        }

        static void Rearrange(Node node)
        {

            // 1) Find the middle point using tortoise and hare method 
            Node slow = node, fast = slow.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // 2) Split the linked list in two halves
            // node1, head of first half    1 -> 2 -> 3
            // node2, head of second half   4 -> 5
            Node node1 = node;
            Node node2 = slow.next;
            slow.next = null;

            // 3) Reverse the second half, i.e., 5 -> 4
            node2 = Reverselist(node2);

            // 4) Merge alternate nodes
            node = new Node(0); // Assign dummy Node

            // curr is the pointer to this dummy Node, which will
            // be used to form the new list
            Node curr = node;
            while (node1 != null || node2 != null)
            {

                // First add the element from first list
                if (node1 != null)
                {
                    curr.next = node1;
                    curr = curr.next;
                    node1 = node1.next;
                }

                // Then add the element from second list
                if (node2 != null)
                {
                    curr.next = node2;
                    curr = curr.next;
                    node2 = node2.next;
                }
            }

            // Assign the head of the new list to head pointer
            node = node.next;
        }
        
        static Node Reverselist(Node node)
        {
            Node prev = null, curr = node, next;
            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            node = prev;
            return node;
        }
                
        static void Push(int new_data)
        {
            Node newNode = new Node(new_data);

            /*Add a node at the end*/
            if (head == null)
                head = last = newNode;
            else
            {
                last.next = newNode;
                last = newNode;
            }

            /*Add a node at the front*/
            //new_node.next = head;
            //head = new_node;

        }
                
        static void Display(Node head)
        {
            Node curr = head;
            while (curr != null)
            {
                Console.Write(curr.data);
                if (curr.next != null)
                    Console.Write(" --> ");

                curr = curr.next;
            }
        }
    }


    /* Node Class */
    class Node
    {
        public int data;
        public Node next;

        // Constructor to create a new node
        public Node(int d)
        {
            data = d;
            next = null;
        }


    }
}
//https://www.geeksforgeeks.org/rearrange-a-given-linked-list-in-place/
