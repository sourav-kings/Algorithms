using System;
using System.Collections.Generic;

namespace Check_If_BinaryTree_Is_Complete
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Let us construct the following Binary Tree which
              is not a complete Binary Tree
                    1
                  /   \
                 2     3
                / \     \
               4   5     6
            */

            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.right = new Node(6);
            //root.right.left = new Node(6);

            if (IsCompleteBT(root) == true)
                Console.WriteLine("Complete Binary Tree");
            else
                Console.WriteLine("NOT Complete Binary Tree");
        }

        /* Given a binary tree, return true if the tree is complete
       else false */
        static bool IsCompleteBT(Node root)
        {
            // Base Case: An empty tree is complete Binary Tree
            if (root == null)
                return true;

            // Create an empty queue
            Queue<Node> queue = new Queue<Node>();

            // Create a flag variable which will be set true
            // when a non full node is seen
            bool flag = false;

            // Do level order traversal using queue.
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                Node temp_node = queue.Dequeue();

                /* Check if left child is present*/
                if (temp_node.left != null)
                {
                    // If we have seen a non full node, and we see a node
                    // with non-empty left child, then the given tree is not
                    // a complete Binary Tree
                    if (flag == true)
                        return false;

                    // Enqueue Left Child
                    queue.Enqueue(temp_node.left);
                }
                // If this a non-full node, set the flag as true
                else
                    flag = true;

                /* Check if right child is present*/
                if (temp_node.right != null)
                {
                    // If we have seen a non full node, and we see a node
                    // with non-empty right child, then the given tree is not
                    // a complete Binary Tree
                    if (flag == true)
                        return false;

                    // Enqueue Right Child
                    queue.Enqueue(temp_node.right);

                }
                // If this a non-full node, set the flag as true
                else
                    flag = true;
            }
            // If we reach here, then the tree is complete Bianry Tree
            return true;
        }
    }

    /* A binary tree node has data, pointer to left child
   and a pointer to right child */
    class Node
    {
        public int data;
        public Node left;
        public Node right;

        // Constructor
        public Node(int d)
        {
            data = d;
            left = null;
            right = null;
        }
    }
}