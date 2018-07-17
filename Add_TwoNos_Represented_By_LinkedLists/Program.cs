using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_TwoNos_Represented_By_LinkedLists
{
    class Program
    {
        static Node head1, head2;
        static void Main(string[] args)
        {
            // creating first list
            head1 = new Node(7);
            head1.next = new Node(5);
            head1.next.next = new Node(9);
            head1.next.next.next = new Node(4);
            head1.next.next.next.next = new Node(6);
            Console.Write("First List is ");
            PrintList(head1);

            // creating seconnd list
            head2 = new Node(8);
            head2.next = new Node(4);
            Console.Write("Second List is ");
            PrintList(head2);

            // add the two lists and see the result
            Node rs = AddTwoLists(head1, head2);
            Console.Write("Resultant List is ");
            PrintList(rs);
        }

        /* Adds contents of two linked lists and return the head node of resultant list */
        static Node AddTwoLists(Node first, Node second)
        {
            Node res = null; // res is head node of the resultant list
            Node prev = null;
            Node temp = null;
            int carry = 0, sum;

            while (first != null || second != null) //while both lists exist
            {
                // Calculate value of next digit in resultant 
                // The next digit is sum of following things
                // (i)  Carry
                // (ii) Next digit of first list (if there is a next digit)
                // (ii) Next digit of second list (if there is a next digit)
                sum = carry + (first != null ? first.data : 0)
                        + (second != null ? second.data : 0);

                // update carry for next calulation
                carry = (sum >= 10) ? 1 : 0;

                // update sum if it is greater than 10
                sum = sum % 10;

                // Create a new node with sum as data
                temp = new Node(sum);

                // if this is the first node then set it as head of
                // the resultant list
                if (res == null)
                    res = temp;
                else // If this is not the first node then connect it to the rest.
                    prev.next = temp;

                // Set prev for next insertion
                prev = temp;

                // Move first and second pointers to next nodes
                if (first != null)
                    first = first.next;
                if (second != null)
                    second = second.next;
            }

            if (carry > 0)
                temp.next = new Node(carry);

            // return head of the resultant list
            return res;
        }
        /* Utility function to print a linked list */

        static void PrintList(Node head)
        {
            while (head != null)
            {
                Console.Write(head.data + " ");
                head = head.next;
            }
            Console.WriteLine("");
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
