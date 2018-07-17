using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boundary_Traversal_Of_BinaryTree
{
    class Program
    {
        /*Given a binary tree, print boundary nodes of the binary tree Anti-Clockwise starting from the root. */
        static Node root;
        static void Main(string[] args)
        {
            root = new Node(20);
            root.left = new Node(8);
            root.left.left = new Node(4);
            root.left.right = new Node(12);
            root.left.right.left = new Node(10);
            root.left.right.right = new Node(14);
            root.right = new Node(22);
            root.right.right = new Node(25);

            //root = new Node(1);
            //root.left = new Node(2);
            //root.right = new Node(3);
            //root.left.left = new Node(4);
            //root.left.right = new Node(5);
            //root.right.right = new Node(6);


            printBoundary(root);
        }


        // A function to do boundary traversal of a given binary tree
        static void printBoundary(Node node)
        {
            if (node == null)
                return;

            Console.Write(node.data + " ");

            // Print the left boundary in top-down manner.
            printBoundaryLeft(node.left);

            // Print all leaf nodes
            printLeaves(node.left);
            printLeaves(node.right);

            // Print the right boundary in bottom-up manner
            printBoundaryRight(node.right);

        }


        // A simple function to print leaf nodes of a binary tree
        static void printLeaves(Node node)
        {
            if (node == null)
                return;

            printLeaves(node.left);

            // Print it if it is a leaf node
            if (node.left == null && node.right == null)
                Console.Write(node.data + " ");

            printLeaves(node.right);

        }

        // A function to print all left boundry nodes, except a leaf node.
        // Print the nodes in TOP DOWN manner
        static void printBoundaryLeft(Node node)
        {
            if (node == null)
                return;

            if (node.left != null)
            {

                // to ensure top down order, print the node
                // before calling itself for left subtree
                Console.Write(node.data + " ");
                printBoundaryLeft(node.left);
            }
            else if (node.right != null)
            {
                Console.Write(node.data + " ");
                printBoundaryLeft(node.right);
            }

            // do nothing if it is a leaf node, this way we avoid
            // duplicates in output

        }

        // A function to print all right boundry nodes, except a leaf node
        // Print the nodes in BOTTOM UP manner
        static void printBoundaryRight(Node node)
        {
            if (node == null)
                return;

            if (node.right != null)
            {
                // to ensure bottom up order, first call for right
                //  subtree, then print this node
                printBoundaryRight(node.right);
                Console.Write(node.data + " ");
            }
            else if (node.left != null)
            {
                printBoundaryRight(node.left);
                Console.Write(node.data + " ");
            }
            // do nothing if it is a leaf node, this way we avoid
            // duplicates in output

        }
    }

    /* A binary tree node has data, pointer to left child
   and a pointer to right child */
    class Node
    {
        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

}
//http://www.geeksforgeeks.org/boundary-traversal-of-binary-tree/
//Average Difficulty : 3.5/5.0
//Based on 118 vote(s)


/*
 * We break the problem in 3 parts:
1. Print the left boundary in top-down manner.
2. Print all leaf nodes from left to right, which can again be sub-divided into two sub-parts:
…..2.1 Print all leaf nodes of left sub-tree from left to right.
…..2.2 Print all leaf nodes of right subtree from left to right.
3. Print the right boundary in bottom-up manner.

We need to take care of one thing that nodes are not printed again. e.g. The left most node is also the leaf node of the tree.
 */


/*
 * ALGO::
 * 
 * 0. 
 * 1. Call the function with root
 * 2. Check node null condition.
 * 3. Print extreme left node in bottom down approach i.e.
 *      Call function 2 with root.
 *      If root.left has value, print it.Recur with left child of root.
 *      Else If root.left is null but root.right has value, print it. recur with right child of root.
 * 6. Print leaves::
 *      Call 3rd function function with root
 *      Recur for left node.
 *      If root has no children, then print it. *      
 *      Recur for right node.
 * 10. Print extreme right node in bottom up approach i.e.
 *       Call function 4 with root.
 *       If root.right has value, print it.Recur with right child of root.
 *       Else If root.right is null but root.left has value, print it. recur with right child of root.
 * 
 *      
 */
