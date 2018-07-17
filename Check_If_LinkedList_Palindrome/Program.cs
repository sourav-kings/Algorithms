using System;

namespace Check_If_LinkedList_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Start with the empty list */
            LinkedList llist = new LinkedList();

            char[] str = { 'a', 'b', 'a', 'c', 'a', 'b', 'a' };
            //String string = new String(str);
            for (int i = 0; i < 7; i++)
            {
                llist.Push(str[i]);
                llist.PrintList();
                if (llist.IsPalindrome() != false)
                {
                    Console.WriteLine("Is Palindrome");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Not Palindrome");
                    Console.WriteLine("");
                }
            }
        }
    }

    /* Java program to check if linked list is palindrome */

    internal class LinkedList
    {
        Node head;  // head of list
        Node slow_ptr, fast_ptr, second_half;

        /* Linked list Node*/
        public class Node
        {
            internal char data;
            internal Node next;

            internal Node(char d)
            {
                data = d;
                next = null;
            }
        }
        /* Function to check if given linked list is
           palindrome or not */
        internal bool IsPalindrome()
        {
            slow_ptr = head; fast_ptr = head;
            Node prev_of_slow_ptr = head;
            Node midnode = null;  // To handle odd size list
            bool res = true; // initialize result

            if (head != null && head.next != null)
            {
                /* Get the middle of the list. Move slow_ptr by 1
                   and fast_ptrr by 2, slow_ptr will have the middle
                   node */
                while (fast_ptr != null && fast_ptr.next != null)
                {
                    fast_ptr = fast_ptr.next.next;

                    /*We need previous of the slow_ptr for
                      linked lists  with odd elements */
                    prev_of_slow_ptr = slow_ptr;
                    slow_ptr = slow_ptr.next;
                }

                /* fast_ptr would become NULL when there are even elements 
                   in the list and not NULL for odd elements. We need to skip  
                   the middle node for odd case and store it somewhere so that
                   we can restore the original list */
                if (fast_ptr != null)
                {
                    midnode = slow_ptr;
                    slow_ptr = slow_ptr.next;
                }

                // Now reverse the second half and compare it with first half
                second_half = slow_ptr;
                prev_of_slow_ptr.next = null; // NULL terminate first half


                Reverse();  // Reverse the second half


                res = CompareLists(head, second_half); // compare


                /* Construct the original list back */
                Reverse(); // Reverse the second half again


                if (midnode != null)
                {
                    // If there was a mid node (odd size case) which                                                         
                    // was not part of either first half or second half.
                    prev_of_slow_ptr.next = midnode;
                    midnode.next = second_half;
                }
                else
                    prev_of_slow_ptr.next = second_half;
            }
            return res;
        }

        /* Function to reverse the linked list  Note that this
           function may change the head */
        void Reverse()
        {
            Node prev = null;
            Node current = second_half;
            Node next;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            second_half = prev;
        }

        /* Function to check if two input lists have same data*/
        bool CompareLists(Node head1, Node head2)
        {
            Node temp1 = head1;
            Node temp2 = head2;

            while (temp1 != null && temp2 != null)
            {
                if (temp1.data == temp2.data)
                {
                    temp1 = temp1.next;
                    temp2 = temp2.next;
                }
                else
                    return false;
            }

            /* Both are empty reurn 1*/
            if (temp1 == null && temp2 == null)
                return true;

            /* Will reach here when one is NULL
               and other is not */
            return false;
        }

        /* Push a node to linked list. Note that this function
           changes the head */
        internal void Push(char new_data)
        {
            /* Allocate the Node &
               Put in the data */
            Node new_node = new Node(new_data);

            /* link the old list off the new one */
            new_node.next = head;

            /* Move the head to point to new Node */
            head = new_node;
        }

        // A utility function to print a given linked list
        internal void PrintList()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + "->");
                temp = temp.next;
            }
            Console.WriteLine("NULL");
        }


    }
}

/*
 * https://www.geeksforgeeks.org/function-to-check-if-a-singly-linked-list-is-palindrome/
 */
