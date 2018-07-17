using System;
using System.Collections.Generic;

namespace RightView_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(6);
            tree.root.right.right = new Node(7);
            tree.root.right.left.right = new Node(8);

            //tree.RightView();
            tree.PrintRightView_Queue(tree.root);
        }
    }

    class BinaryTree
    {
        internal Node root;
        Max_level max = new Max_level();

        // Recursive function to print right view of a binary tree.
        internal void RightViewUtil(Node node, int level, Max_level max_level)
        {

            // Base Case
            if (node == null)
                return;

            // If this is the last Node of its level
            if (max_level.max_level < level)
            {
                Console.WriteLine(node.data + " ");
                max_level.max_level = level;
            }

            // Recur for right subtree first, then left subtree
            RightViewUtil(node.right, level + 1, max_level);
            RightViewUtil(node.left, level + 1, max_level);
        }

        internal void RightView()
        {
            RightView(root);
        }

        // A wrapper over rightViewUtil()
        void RightView(Node node)
        {
            RightViewUtil(node, 1, max);
        }


        // function to print right view of binary tree
        internal void PrintRightView_Queue(Node root)
        {
            if (root == null)
                return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                // number of nodes at current level
                int n = queue.Count;

                // Traverse all nodes of current level 
                for (int i = 1; i <= n; i++)
                {
                    Node temp = queue.Dequeue();

                    // Print the right most element at 
                    // the level
                    if (i == n)
                        Console.WriteLine(temp.data + " ");

                    // Add left node to queue
                    if (temp.left != null)
                        queue.Enqueue(temp.left);

                    // Add right node to queue
                    if (temp.right != null)
                        queue.Enqueue(temp.right);
                }
            }
        }
    }

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


    // class to access maximum level by reference
    class Max_level
    {
        internal int max_level;
    }

}
