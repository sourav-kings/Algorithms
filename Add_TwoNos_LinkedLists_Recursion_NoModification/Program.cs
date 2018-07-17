using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_TwoNos_LinkedLists_Recursion_NoModification
{
    class Program
    {
        static Node head1, head2, result;
        static Node curr = null;
        static int carry = 0;
        static int sum = 0;

        static void Main(string[] args)
        {
            //head1 = new Node(7);
            //head1.next = new Node(8);
            //head1.next.next = new Node(9);
            //head1.next.next.next = new Node(9);
            //head1.next.next.next.next = new Node(8);
            //head1.next.next.next.next.next = new Node(7);
            //head1.next.next.next.next.next.next = new Node(9);

            //head2 = new Node(7);
            //head2.next = new Node(4);
            //head2.next.next = new Node(5);
            //head2.next.next.next = new Node(8);
            //head2.next.next.next.next = new Node(3);


            /*Test Data*/
            head1 = new Node(5);
            head1.next = new Node(9);
            head1.next.next = new Node(4);

            head2 = new Node(1);
            head2.next = new Node(3);
            head2.next.next = new Node(4);

            int size1 = getSize(head1);
            int size2 = getSize(head2);

            Console.Write("List-1 : ");
            printList(head1);
            Console.Write("\nList-2 : ");
            printList(head2);
            Console.Write("\n-------------------------");
            Console.Write("\nSum    : ");
            //addTwoLists(head1, head2, size1, size2);
            addTwoLists_TestInProgress(head1, head2, size1, size2);
            printList(result);
        }

        static void addTwoLists(Node node1, Node node2, int size1, int size2)
        {

            if (node1.next != null && node2.next != null & (size1 == size2))
                addTwoLists(node1.next, node2.next, size1 - 1, size2 - 1);
            else if (node1.next != null && (size1 > size2))
                addTwoLists(node1.next, node2, size1 - 1, size2);
            else if (node2.next != null && (size2 > size1))
                addTwoLists(node1, node2.next, size1, size2 - 1);

            addTwoNodes(node1, node2, size1, size2);
        }

        static void addTwoLists_TestInProgress(Node node1, Node node2, int size1, int size2)
        {
            if ((size1 == size2))
            {
                if (node1.next != null && node2.next != null)
                    addTwoLists(node1.next, node2.next, size1 - 1, size2 - 1);
            }
            else
            {
                if (node1.next != null && (size1 > size2))
                    addTwoLists(node1.next, node2, size1 - 1, size2);
                else if (node2.next != null && (size2 > size1))
                    addTwoLists(node1, node2.next, size1, size2 - 1);
            }

            addTwoNodes(node1, node2, size1, size2);
        }

        static void addTwoNodes(Node node1, Node node2, int size1, int size2)
        {
            int carry_prev = carry;
            sum = carry + (node1 != null ? (size1 >= size2 ? node1.data : 0) : 0) +
                            (node2 != null ? (size2 >= size1 ? node2.data : 0) : 0);

            carry = (sum >= 10) ? 1 : 0;
            sum = sum % 10;


            /*Very important to understand*/
            /* below conditional statement is for replacing the node in the sum which
             has come into existence because of prev carry forward.
             Take example of 494 + 34 */

            /*IMP: We're creating a new node, everytime a carry*/
            if (carry_prev == 0)
                result = push(sum, result);//creates a new node with "sum" and assign "result" as new node's next
            else
                result.data = sum; // if previous_carry exists, add
            
            if (carry > 0)
                result = push(carry, result);// if currrent carry exists, then append result as next to carry.
        }
        /*agar prev_carry hai, tab already wo carry ka value, result waale linked list me aa gaya. 
         Isliye, hum pehle "prev_carry" check karte h, agar hai to result me naya node NAHI banayenge, aur exisitng me hi replace kr denge
         494 + 34 ka example debug karo.*/
        static int getSize(Node node)
        {
            int size = 0;
            while (node != null)
            {
                size++;
                node = node.next;
            }
            return size;
        }

        static void printList(Node node)
        {
            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
        }

        /// <summary>
        /// Creates a new node with "value" and attache "next" to it.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static Node push(int value, Node next)
        {
            Node newNode = new Node(value);
            newNode.next = next;
            return newNode;
        }
    }

    class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }
}


/*
 http://www.geeksforgeeks.org/sum-of-two-linked-lists/

    Time Complexity: O(m+n) where m and n are the sizes of given two linked lists.


     It is not allowed to modify the lists. Also, not allowed to use explicit extra space (Hint: Use Recursion).
     In this problem, most significant node is first node and least significant digit is last node and 
     we are not allowed to modify the lists. Recursion is used here to calculate sum from right to left.

        Average Difficulty : 3.6/5.0
        Based on 96 vote(s)






    Following are the steps.
1) Calculate sizes of given two linked lists.
2) If sizes are same, then calculate sum using recursion. Hold all nodes in recursion call stack till the rightmost node, 
calculate sum of rightmost nodes and forward carry to left side.
3) If size is not same, then follow below steps:
….a) Calculate difference of sizes of two linked lists. Let the difference be diff
….b) Move diff nodes ahead in the bigger linked list. Now use step 2 to calculate sum of smaller list and 
right sub-list (of same size) of larger list. Also, store the carry of this sum.
….c) Calculate sum of the carry (calculated in previous step) with the remaining left sub-list of larger list. 
Nodes of this sum are added at the beginning of sum list obtained previous step.
     */
