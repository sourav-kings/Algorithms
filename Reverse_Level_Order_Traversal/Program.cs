using System;

namespace Reverse_Level_Order_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            // Let us create trees shown in above diagram
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("Level Order traversal of binary tree is : ");
            tree.ReverseLevelOrder(tree.root);
        }
    }

    

    class BinaryTree
    {
        internal Node root;

        /* Function to print REVERSE level order traversal a tree*/
        internal void ReverseLevelOrder(Node node)
        {
            int h = Height(node);
            int i;
            for (i = h; i >= 1; i--)
            //THE ONLY LINE DIFFERENT FROM NORMAL LEVEL ORDER
            {
                PrintGivenLevel(node, i);
            }
        }

        /* Print nodes at a given level */
        void PrintGivenLevel(Node node, int level)
        {
            if (node == null)
                return;
            if (level == 1)
                Console.WriteLine(node.data + " ");
        else if (level > 1)
            {
                PrintGivenLevel(node.left, level - 1);
                PrintGivenLevel(node.right, level - 1);
            }
        }

        /* Compute the "height" of a tree -- the number of
         nodes along the longest path from the root node
         down to the farthest leaf node.*/
        int Height(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                /* compute the height of each subtree */
                int lheight = Height(node.left);
                int rheight = Height(node.right);

                /* use the larger one */
                if (lheight > rheight)
                    return (lheight + 1);
                else
                    return (rheight + 1);
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
            left = right;
        }
    }
}

/*
 * https://www.geeksforgeeks.org/reverse-level-order-traversal/
 */
