using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detect_And_Remove_Loop_In_LinkedList
{
    /* a function detectAndRemoveLoop() that checks whether a given Linked List contains loop and 
     * if loop is present then removes the loop and returns true. 
     * And if the list doesn’t contain loop then returns false.
     */
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

            //head.next.next.next.next.next = head;//loop --> 5 connects to 1.
            //head.next.next.next.next.next = head.next;//loop --> 5 connects to 2.
            head.next.next.next.next.next = head.next.next;//loop --> 5 connects to 3.



            //head = new Node(1);
            //head.next = new Node(2);
            //head.next.next = new Node(3);
            //head.next.next.next = new Node(4);
            //head.next.next.next.next = new Node(5);


            ////Creating a loop for testing 
            //head.next.next.next.next.next = head.next.next.next;//loop --> 5 connects to 4.


            detectAndRemoveLoop(head);
            Console.WriteLine("Linked List after removing loop : ");
            printList(head);
        }

        // Function that detects loop in the list
        static int detectAndRemoveLoop(Node node)
        {
            Node slow = node, fast = node;
            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;


                // If slow and fast meet at same point then loop is present
                if (slow == fast)
                {
                    //removeLoop(slow, node);
                    removeLoopFaster(slow, node);
                    return 1;
                }
            }
            return 0;
        }

        // Function to remove loop
        static void removeLoop(Node loop, Node curr)
        {
            Node ptr1 = null, ptr2 = null;

            /* Set a pointer to the beging of the Linked List and
             move it one by one to find the first node which is
             part of the Linked List */
            ptr1 = curr;
            while (1 == 1)
            {

                /* Now start a pointer from loop_node and check if it ever
                 reaches ptr2 */
                ptr2 = loop;
                while (ptr2.next != loop && ptr2.next != ptr1)
                {
                    ptr2 = ptr2.next;
                }

                /* If ptr2 reahced ptr1 then there is a loop. So break the
                 loop */
                if (ptr2.next == ptr1)
                {
                    break;
                }

                /* If ptr2 did't reach ptr1 then try the next node after ptr1 */
                ptr1 = ptr1.next;
            }

            /* After the end of loop ptr2 is the last node of the loop. So
             make next of ptr2 as NULL */
            ptr2.next = null;
        }

        // Function to remove loop
        static void removeLoopFaster(Node loop, Node head)
        {
            Node ptr1 = loop;
            Node ptr2 = loop;

            // STEP I:: 
            //Count the number of nodes in loop
            int k = 1, i;
            while (ptr1.next != ptr2)
            {
                ptr1 = ptr1.next;
                k++;
            }

            // Fix one pointer to head
            // And the other pointer to k nodes after head
            ptr1 = head;
            ptr2 = head;
            for (i = 0; i < k; i++)
            {
                ptr2 = ptr2.next;
            }

            /*  Move both pointers at the same pace,
             they will meet at loop starting node */
            while (ptr2 != ptr1)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }

            // Get pointer to the last node
            ptr2 = ptr2.next;
            while (ptr2.next != ptr1)
            {
                ptr2 = ptr2.next;
            }

            /* Set the next node of the loop ending node
             to fix the loop */
            ptr2.next = null;
        }

        //static void removeLoopFaster(Node loop, Node head)
        //{
        //    Node ptr1 = loop;
        //    Node ptr2 = loop;

        //    // Count the number of nodes in loop
        //    int k = 1, i;
        //    while (ptr1.next != ptr2)
        //    {
        //        ptr1 = ptr1.next;
        //        k++;
        //    }

        //    // Fix one pointer to head
        //    ptr1 = head;

        //    // And the other pointer to k nodes after head
        //    ptr2 = head;
        //    for (i = 0; i < k; i++)
        //    {
        //        ptr2 = ptr2.next;
        //    }

        //    /*  Move both pointers at the same pace,
        //     they will meet at loop starting node */
        //    while (ptr2 != ptr1)
        //    {
        //        ptr1 = ptr1.next;
        //        ptr2 = ptr2.next;
        //    }

        //    // Get pointer to the last node
        //    ptr2 = ptr2.next;
        //    while (ptr2.next != ptr1)
        //    {
        //        ptr2 = ptr2.next;
        //    }

        //    /* Set the next node of the loop ending node
        //     to fix the loop */
        //    ptr2.next = null;
        //}






        // Function to print the linked list
        static void printList(Node node)
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

//http://www.geeksforgeeks.org/detect-and-remove-loop-in-a-linked-list/

//http://www.geeksforgeeks.org/?p=112 
//(function to detect loop in a linked list)


// Average Difficulty : 3.4/5.0
//Based on 183 vote(s)




/*
 *
 * Before trying to remove the loop, we must detect it. 
 * Techniques discussed in the above post can be used to detect loop. 
 * To remove loop, all we need to do is to get pointer to the last node of the loop. 
 * For example, node with value 5 in the above diagram. 
 * Once we have pointer to the last node, we can make the next of this node as NULL and loop is gone.

    
    We can easily use Hashing or Visited node techniques (discussed in the above mentioned post) to get the pointer to the last node. 
        Idea is simple: the very first node whose next is already visited (or hashed) is the last node.
    

    We can also use Floyd Cycle Detection algorithm to detect and remove the loop. 
    In the Floyd’s algo, the slow and fast pointers meet at a loop node. We can use this loop node to remove cycle. 
    There are following two different ways of removing loop when Floyd’s algorithm is used for Loop detection.




 * 
 *Floyd’s Cycle-Finding Algorithm:
This is the fastest method. Traverse linked list using two pointers.  
Move one pointer by one and other pointer by two.  
If these pointers meet at some node then there is a loop.  
If pointers do not meet then linked list doesn’t have loop. 
 * 
 */
//Method 3 (Better Solution)
//This method is also dependent on Floyd’s Cycle detection algorithm.
//1) Detect Loop using Floyd’s Cycle detection algo and get the pointer to a loop node.
//2) Count the number of nodes in loop. Let the count be k.
//3) Fix one pointer to the head and another to kth node from head.
//4) Move both pointers at the same pace, they will meet at loop starting node.
//5) Get pointer to the last node of loop and make next of it as NULL.