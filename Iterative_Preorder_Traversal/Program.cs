using System;
using System.Collections.Generic;

namespace Iterative_Preorder_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(10);
            tree.root.left = new Node(8);
            tree.root.right = new Node(2);
            tree.root.left.left = new Node(3);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(2);
            tree.iterativePreorder();
        }
    }

    class BinaryTree
    {

        internal Node root;

        internal void iterativePreorder()
        {
            iterativePreorder(root);
        }

        // An iterative process to print preorder traversal of Binary tree
        void iterativePreorder(Node node)
        {

            // Base Case
            if (node == null)
            {
                return;
            }

            // Create an empty stack and push root to it
            Stack<Node> nodeStack = new Stack<Node>();
            nodeStack.Push(root);

            /* Pop all items one by one. Do following for every popped item
             a) print it
             b) push its right child
             c) push its left child
             Note that right child is pushed first so that left is processed first */
            while (nodeStack.Count != 0)
            {

                // Pop the top item from stack and print it
                Node mynode = nodeStack.Peek();
                Console.Write(mynode.data + " ");
                nodeStack.Pop();

                // Push right and left children of the popped node to stack
                if (mynode.right != null)
                {
                    nodeStack.Push(mynode.right);
                }
                if (mynode.left != null)
                {
                    nodeStack.Push(mynode.left);
                }
            }
        }
    }



    // A binary tree node
    class Node
    {

        internal int data;
        internal Node left, right;

        internal Node(int item)
        {
            data = item;
            left = right = null;
        }
    }
}

/*
 * https://www.geeksforgeeks.org/iterative-preorder-traversal/
 */
