using System;

namespace Determine_If_BinaryTree_HeightBalanced
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.left.left.left = new Node(8);

            if (IsBalanced(root))
                Console.WriteLine("Tree is balanced");
            else
                Console.WriteLine("Tree is not balanced");
        }

        /* Returns true if binary tree with root as root is height-balanced */
        static bool IsBalanced(Node node)
        {
            int lh; /* for height of left subtree */

            int rh; /* for height of right subtree */

            /* If tree is empty then return true */
            if (node == null)
                return true;

            /* Get the height of left and right sub trees */
            lh = Height(node.left);
            rh = Height(node.right);

            if (Math.Abs(lh - rh) <= 1
                    && IsBalanced(node.left)
                    && IsBalanced(node.right))
                return true;

            /* If we reach here then tree is not height-balanced */
            return false;
        }

        /* UTILITY FUNCTIONS TO TEST isBalanced() FUNCTION */
        /*  The function Compute the "height" of a  Height is the
            number of nodes along the longest path from the root node
            down to the farthest leaf node.*/
        static int Height(Node node)
        {
            /* base case tree is empty */
            if (node == null)
                return 0;

            /* If tree is not empty then height = 1 + max of left
             height and right heights */
            return 1 + Math.Max(Height(node.left), Height(node.right));
        }


    }

    class Node
    {
        public int data;
        public Node left, right;
        public Node(int d)
        {
            data = d;
            left = right = null;
        }
    }
}

/*
 * https://www.geeksforgeeks.org/how-to-determine-if-a-binary-tree-is-balanced/
 * 
 * To check if a tree is height-balanced, get the height of left and right subtrees. 
 * Return true if difference between heights is not more than 1 and left and right subtrees are balanced, otherwise return false.
 */
