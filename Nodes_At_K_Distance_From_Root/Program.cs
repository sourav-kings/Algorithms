using System;

namespace Nodes_At_K_Distance_From_Root
{
    class Program
    {
        /* Driver program to test above functions */
        public static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            /* Constructed binary tree is
                    1
                  /   \
                 2     3
                /  \   /
               4    5 8 
            */
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.left = new Node(8);

            tree.PrintKDistant(tree.root, 2);
        }
    }

    class BinaryTree
    {
        internal Node root;

        internal void PrintKDistant(Node node, int k)
        {
            if (node == null)
                return;

            if (k == 0)
            {
                Console.WriteLine(node.data + " ");
                return;
            }

            PrintKDistant(node.left, k - 1);
            PrintKDistant(node.right, k - 1);
            
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
}

//https://www.geeksforgeeks.org/print-nodes-at-k-distance-from-root/
/*
 * https://www.geeksforgeeks.org/print-nodes-at-k-distance-from-root/
 */
