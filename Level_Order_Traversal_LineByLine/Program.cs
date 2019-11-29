using System;
using System.Collections.Generic;

namespace Level_Order_Traversal_LineByLine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let us create binary tree shown in above diagram
            /*               1
                        /     \
                       2       3
                     /   \       \
                    4     5       6
             */

            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.right = new Node(6);

            PrintLevelOrder(root);
        }



        // Iterative method to do level order traversal line by line
        static void PrintLevelOrder(Node root)
        {
            // Base Case
            if (root == null)
                return;

            // Create an empty queue for level order tarversal
            Queue<Node> q = new Queue<Node>();

            // Enqueue Root and initialize height
            q.Enqueue(root);


            while (true)
            {
                // nodeCount (queue size) indicates number of nodes
                // at current level.
                int nodeCount = q.Count;
                if (nodeCount == 0)
                    break;

                // Dequeue all nodes of current level and Enqueue all
                // nodes of next level
                while (nodeCount > 0)
                {
                    Node node = q.Peek();
                    Console.Write(node.data + " ");
                    q.Dequeue();
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                    nodeCount--;
                }
                Console.WriteLine();
            }
        }
    }

    // A Binary Tree Node
    class Node
    {
        internal int data;
        internal Node left;
        internal Node right;

        // constructor
        internal Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/print-level-order-traversal-line-line/
 * 
 * 
 * Print level order traversal line by line | Set 1
 * Note that this is different from simple level order traversal 
 * where we need to print all nodes together. 
 * Here we need to print nodes of different levels in different lines.
 * 
 * 
 * A simple solution is to print use the recursive function discussed in the level order traversal post 
 * and print a new line after every call to printGivenLevel().
 * The time complexity of the above solution is O(n*n)
 * 
 * 
 * O(n) solution is similar to "Iterative Method to find Height of Binary Tree"
 * 
 */
