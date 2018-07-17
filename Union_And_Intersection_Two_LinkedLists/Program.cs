using System;
using System.Collections;
using System.Collections.Generic;

namespace Union_And_Intersection_Two_LinkedLists
{
    class Program
    {
        
        static void Main(string[] args)
        {
                LinkedList llist1 = new LinkedList();
                LinkedList llist2 = new LinkedList();
                LinkedList union = new LinkedList();
                LinkedList intersection = new LinkedList();

                /*create a linked list 10->15->4->20 */
                llist1.Push(20);
                llist1.Push(4);
                llist1.Push(15);
                llist1.Push(10);

                /*create a linked list 8->4->2->10 */
                llist2.Push(10);
                llist2.Push(2);
                llist2.Push(4);
                llist2.Push(8);

                intersection = intersection.GetIntersection(llist1.head,
                                                          llist2.head);
                union = union.GetUnion(llist1.head, llist2.head);

                Console.WriteLine("First List is");
                llist1.PrintList();

                Console.WriteLine("Second List is");
                llist2.PrintList();

                Console.WriteLine("Intersection List is");
                intersection.PrintList();

                Console.WriteLine("Union List is");
                union.PrintList();
        }
    }

    class LinkedList
    {
        internal Node head; // head of list
        /* Linked list Node*/
        internal class Node
        {
            internal int data;
            internal Node next;
            internal Node(int d)
            {
                data = d;
                next = null;
            }
        }

        /* Utility function to print list */
        internal void PrintList()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }

        /* Inserts a node at start of linked list */
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

        internal void Append(int new_data)
        {
            if (this.head == null)
            {
                Node n = new Node(new_data);
                this.head = n;
                return;
            }
            Node n1 = this.head;
            Node n2 = new Node(new_data);
            while (n1.next != null)
            {
                n1 = n1.next;
            }

            n1.next = n2;
            n2.next = null;
        }

        /* A utilty function that returns true if data is
        present in linked list else return false */
        internal bool IsPresent(Node head, int data)
        {
            Node t = head;
            while (t != null)
            {
                if (t.data == data)
                    return true;
                t = t.next;
            }
            return false;
        }

        internal LinkedList GetIntersection(Node head1, Node head2)
        {
            HashSet<int> hset = new HashSet<int>();
            Node n1 = head1;
            Node n2 = head2;
            LinkedList result = new LinkedList();

            // loop stores all the elements of list1 in hset
            while (n1 != null)
            {
                if (hset.Contains(n1.data))
                    hset.Add(n1.data);
                else
                    hset.Add(n1.data);

                n1 = n1.next;
            }

            //For every element of list2 present in hset
            //loop inserts the element into the result
            while (n2 != null)
            {
                if (hset.Contains(n2.data))
                    result.Push(n2.data);

                n2 = n2.next;
            }
            return result;
        }

        internal LinkedList GetUnion(Node head1, Node head2)
        {
            // HashMap that will store the 
            // elements of the lists with Dictionary counts
            Dictionary<int, int> hmap = new Dictionary<int, int>();
            Node n1 = head1;
            Node n2 = head2;
            LinkedList result = new LinkedList();

            // loop inserts the elements and the count of 
            // that element of list1 into the hmap
            while (n1 != null)
            {
                if (hmap.ContainsKey(n1.data))
                {
                    int val = hmap[n1.data];
                    hmap[n1.data] = val + 1;
                }
                else
                {
                    hmap[n1.data] = 1;
                }
                n1 = n1.next;
            }

            // loop further adds the elements of list2 with 
            // their counts into the hmap 
            while (n2 != null)
            {
                if (hmap.ContainsKey(n2.data))
                {
                    int val = hmap[n2.data];
                    hmap[n2.data] = val + 1;
                }
                else
                {
                    hmap[n2.data] = 1;
                }
                n2 = n2.next;
            }

            // Eventually add all the elements
            // into the result that are present in the hmap            
            foreach (int a in hmap.Keys)
                result.Append(a);

            return result;
        }


    }
}

//https://www.geeksforgeeks.org/union-and-intersection-of-two-linked-lists/
