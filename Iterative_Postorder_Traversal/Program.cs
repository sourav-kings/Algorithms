using System;
using System.Collections.Generic;

namespace Iterative_Postorder_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let us construct the tree 
            // shown in above figure

            node root = null;
            root = new node(1);
            root.left = new node(2);
            root.right = new node(3);
            root.left.left = new node(4);
            root.left.right = new node(5);
            root.right.left = new node(6);
            root.right.right = new node(7);

            postOrderIterative(root);
        }

        static Stack<node> s1, s2;

        static void postOrderIterative(node root)
        {
            // Create two stacks
            s1 = new Stack<node>();
            s2 = new Stack<node>();

            if (root == null)
                return;

            // push root to first stack
            s1.Push(root);

            // Run while first stack is not empty
            while (s1.Count != 0)
            {
                // Pop an item from s1 and push it to s2
                node temp = s1.Pop();
                s2.Push(temp);

                // Push left and right children of 
                // removed item to s1
                if (temp.left != null)
                    s1.Push(temp.left);
                if (temp.right != null)
                    s1.Push(temp.right);
            }

            // Print all elements of second stack
            while (s2.Count != 0)
            {
                node temp = s2.Pop();
                Console.Write(temp.data + " ");
            }
        }
    }

    class node
    {
        internal int data;
        internal node left, right;

        internal node(int data)
        {
            this.data = data;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/iterative-postorder-traversal/
 */
