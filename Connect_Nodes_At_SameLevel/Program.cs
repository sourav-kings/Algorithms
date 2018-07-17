using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_Nodes_At_SameLevel
{
    class Program
    {
        //Must be a complete binary tree, or else this algo wont work.

        static Node root;
        static void Main(string[] args)
        {
            /* Constructed binary tree is
                  10
                /    \
               8      2
              / \    / \
             3   6  7   5
             */
            root = new Node(10);
            root.left = new Node(8);
            root.right = new Node(2);
            root.left.left = new Node(3);
            root.left.right = new Node(6);
            root.right.left = new Node(7);
            root.right.right = new Node(5);


            // Populates nextRight pointer in all nodes
            root.nextRight = null;
            connectRecur(root);


            // Let us check the values of nextRight pointers
            Console.WriteLine("Following are populated nextRight pointers in "
                    + "the tree" + "(-1 is printed if there is no nextRight)");
            int a = root.nextRight != null ? root.nextRight.data : -1;
            Console.WriteLine("nextRight of " + root.data + " is "
                    + a);
            int b = root.left.nextRight != null ?
                                        root.left.nextRight.data : -1;
            Console.WriteLine("nextRight of " + root.left.data + " is "
                    + b);
            int c = root.right.nextRight != null ?
                                       root.right.nextRight.data : -1;
            Console.WriteLine("nextRight of " + root.right.data + " is "
                    + c);
            int d = root.left.left.nextRight != null ?
                                  root.left.left.nextRight.data : -1;
            Console.WriteLine("nextRight of " + root.left.left.data + " is "
                    + d);
            int e = root.left.right.nextRight != null ?
                                 root.left.right.nextRight.data : -1;
            Console.WriteLine("nextRight of " + root.left.right.data + " is "
                    + e);
            int f = root.right.left.nextRight != null ?
                     root.right.left.nextRight.data : -1;
            Console.WriteLine("nextRight of " + root.right.left.data + " is "
                    + f);
            int g = root.right.right.nextRight != null ?
                    root.right.right.nextRight.data : -1;
            Console.WriteLine("nextRight of " + root.right.right.data + " is "
                    + g);
        }

        // Sets the nextRight of root and calls connectRecur() for other nodes
        //static void connect(Node p)
        //{

        //    // Set the nextRight for root
        //    p.nextRight = null;

        //    // Set the next right for rest of the nodes (other than root)
        //    connectRecur(p);
        //}

        /* Set next right of all descendents of p.
           Assumption:  p is a compete binary tree */
        static void connectRecur(Node p)
        {
            // Base case
            if (p == null)
                return;

            // Set the nextRight pointer for p's left child
            if (p.left != null)
                p.left.nextRight = p.right;

            // Set the nextRight pointer for p's right child
            // p->nextRight will be NULL if p is the right most child 
            // at its level
            if (p.right != null)
                p.right.nextRight = (p.nextRight != null) ?
                                             p.nextRight.left : null;

            // Set nextRight for other nodes in pre order fashion
            connectRecur(p.left);
            connectRecur(p.right);
        }
    }

    // A binary tree node
    class Node
    {
        public int data;
        public Node left, right, nextRight;

        public Node(int item)
        {
            data = item;
            left = right = nextRight = null;
        }
    }
}

//http://www.geeksforgeeks.org/connect-nodes-at-same-level/

//Average Difficulty : 3.3/5.0
//Based on 108 vote(s)


/*
 
    
    Why doesn’t method 2 work for trees which are not Complete Binary Trees?
Let us consider following tree as an example. In Method 2, we set the nextRight pointer in pre order fashion. 
When we are at node 4, we set the nextRight of its children which are 8 and 9 (the nextRight of 4 is already set as node 5). 
nextRight of 8 will simply be set as 9, but nextRight of 9 will be set as NULL which is incorrect. 
We can’t set the correct nextRight, because when we set nextRight of 9, we only have nextRight of node 4 and ancestors of node 4, 
we don’t have nextRight of nodes in right subtree of root.

        1
      /    \
    2        3
   / \      /  \
  4   5    6    7
 / \           / \  
8   9        10   11


 */
