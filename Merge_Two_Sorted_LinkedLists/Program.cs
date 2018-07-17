using System;

namespace Merge_Two_Sorted_LinkedLists
{
    class Program
    {
        static Node a;
        static Node b;
        static void Main(string[] args)
        {
            a = new Node(5);
            a.next = new Node(10);
            a.next.next = new Node(15);

            b = new Node(2);
            b.next = new Node(3);
            b.next.next = new Node(20);

            //Node result = SortedMerge(a, b);
            Node result = SortedMerge_Faster();
            PrintList(result);
        }

        static Node SortedMerge(Node a, Node b)
        {
            Node result = null;

            /* Base cases */
            if (a == null)
                return (b);
            else if (b == null)
                return (a);

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
            return (result);
        }


        //Method 1 (Using Dummy Nodes)
        /* Takes two lists sorted in increasing order, and splices
            their nodes together to make one big sorted list which
            is returned.  */
        static Node SortedMerge_Faster()
        {
            /* a dummy first node to hang the result on */
            Node dummy = new Node(-1);

            /* tail points to the last result node  */
            Node tail = dummy;

            /* so tail.next is the place to add new nodes
              to the result. */
            dummy.next = null;
            while (1 == 1)
            {
                if (a == null)
                {
                    /* if either list runs out, use the
                       other list */
                    tail.next = b;
                    break;
                }
                else if (b == null)
                {
                    tail.next = a;
                    break;
                }
                if (a.data <= b.data)
                    MoveNode(ref tail, ref a);
                else
                    MoveNode(ref tail, ref b);

                tail = tail.next;
            }
            return (dummy.next);
        }




        /* UTILITY FUNCTIONS */
        /* MoveNode() function takes the node from the front of the
           source, and move it to the front of the dest.
           It is an error to call this with the source list empty.

           Before calling MoveNode():
           source == {1, 2, 3}
           dest == {1, 2, 3}

           Affter calling MoveNode():
           source == {2, 3}
           dest == {1, 1, 2, 3} */
        static void MoveNode(ref Node destRef, ref Node sourceRef)
        {
            /* the front source node  */
            Node newNode = sourceRef;
            if (sourceRef != null)
            {
                Node temp = sourceRef;

                /* Advance the source pointer */
                sourceRef = sourceRef.next;
                
                /* Update dest with temp */
                destRef.next = newNode;
            }

        }




        /* Function to print nodes in a given linked list */
        static void PrintList(Node node)
        {
            while (node != null)
            {
                Console.Write(node.data + " -> ");
                node = node.next;
            }
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
 * https://www.geeksforgeeks.org/merge-two-sorted-linked-lists/
 * 
 * Method A (Using Recursion)
    Merge is one of those nice recursive problems 
    where the recursive solution code is much cleaner than the iterative code. 
    You probably wouldn’t want to use the recursive version for production code however, 
    because it will use stack space which is proportional to the length of the lists.


 * Method B (Using Dummy Nodes)
 * The loop proceeds, removing one node from either ‘a’ or ‘b’, and adding it to tail. 
 * When we are done, the result is in dummy.next.
 * 
 */
