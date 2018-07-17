using System;

namespace MergeSort_Linked_Lists
{
    class Program
    {
        static Node head;  // head of list

        static void Main(string[] args)
        {
            /*
             * Let us create a unsorted linked lists to test the functions Created
             * lists shall be a: 2->3->20->5->10->15
             */
            Push(15);
            Push(10);
            Push(5);
            Push(20);
            Push(3);
            Push(2);

            Console.WriteLine("Linked List without sorting is :");
            PrintList(head);

            // Apply merge Sort
            head = MergeSort(head);
            Console.WriteLine("\n Sorted Linked List is: ");
            PrintList(head);           
        }

        static Node MergeSort(Node h)
        {
            // Base case : if head is null
            if (h == null || h.next == null)
            {
                return h;
            }

            // get the middle of the list
            Node middle = GetMiddle(h);
            Node nextofmiddle = middle.next;

            // set the next of middle Node to null
            middle.next = null;

            // Apply mergeSort on left list
            Node left = MergeSort(h);

            // Apply mergeSort on right list
            Node right = MergeSort(nextofmiddle);

            // Merge the left and right lists
            Node sortedlist = SortedMerge(left, right);
            return sortedlist;
        }

        static Node SortedMerge(Node a, Node b)
        {
            Node result = null;
            /* Base cases */
            if (a == null)
                return b;
            if (b == null)
                return a;

            /* Pick either a or b, and recur */
            if (a.data <= b.data)
            {
                result = a;
                result.next = SortedMerge(a.next, b);
            }
            else
            {
                result = b;
                result.next = SortedMerge(a, b.next);
            }
            return result;

        }

        // Utility function to get the middle of the linked list
        static Node GetMiddle(Node h)
        {
            //Base case
            if (h == null)
                return h;
            Node fastptr = h.next;
            Node slowptr = h;

            // Move fastptr by two and slow ptr by one
            // Finally slowptr will point to middle Node
            while (fastptr != null)
            {
                fastptr = fastptr.next;
                if (fastptr != null)
                {
                    slowptr = slowptr.next;
                    fastptr = fastptr.next;
                }
            }
            return slowptr;
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
        
        // Utility function to print the linked list
        static void PrintList(Node headref)
        {
            while (headref != null)
            {
                Console.Write(headref.data + " ");
                headref = headref.next;
            }
            Console.WriteLine();
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
