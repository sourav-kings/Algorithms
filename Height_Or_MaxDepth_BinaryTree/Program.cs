using System;
using System.Collections.Generic;

namespace Height_Or_MaxDepth_BinaryTree
{
    class Program
    {
        /* Driver program to test above functions */
        public static void Main(String[] args)
        {
            BinaryTree tree = new BinaryTree();

            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("Height of tree is : " +
                                          tree.MaxDepth(tree.root));


            Console.WriteLine("Height of tree is : " +
                                          tree.MaxDepth_NonRecursive(tree.root)); 
        }
    }

    class BinaryTree
    {
        internal Node root;

        /* Compute the "maxDepth" of a tree -- the number of 
           nodes along the longest path from the root node 
           down to the farthest leaf node.*/
        internal int MaxDepth(Node node)
        {
            if (node == null)
                return 0;

            int lDepth = MaxDepth(node.left);
            int rDepth = MaxDepth(node.right);

            return (lDepth > rDepth) ? (lDepth + 1) : (rDepth + 1);
        }


        // Iterative method to find height of Bianry Tree
        internal int MaxDepth_NonRecursive(Node node)
        {
            // Base Case
            if (node == null)
                return 0;

            // Create an empty queue for level order tarversal
            Queue<Node> q = new Queue<Node>();

            // Enqueue Root and initialize height
            q.Enqueue(node);
            int height = 0;

            while (1 == 1)
            {
                // nodeCount (queue size) indicates number of nodes
                // at current lelvel.
                int currentLevel_nodeCount = q.Count;
                if (currentLevel_nodeCount == 0)
                    return height;
                height++;

                // Dequeue all nodes of current level and Enqueue all
                // nodes of next level
                while (currentLevel_nodeCount > 0)
                {
                    Node newnode = q.Peek();
                    q.Dequeue();
                    if (newnode.left != null)
                        q.Enqueue(newnode.left);
                    if (newnode.right != null)
                        q.Enqueue(newnode.right);
                    currentLevel_nodeCount--;
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
 * Observation -- 17th Feb 2023
 * 
 * Queue 
 * -- 1st loop to elevate levels
 * -- 2nd loop to cover all nodes for the curent level
 */