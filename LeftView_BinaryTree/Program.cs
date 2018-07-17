using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftView_BinaryTree
{
    class Program
    {

        static Node root;
        static int max_level = 0;

        static void Main(string[] args)
        {
            root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.right.left = new Node(4);
            root.right.right = new Node(5);

            //leftView();
            leftViewUtil(root, 1);
        }

        // recursive function to print left view
        static void leftViewUtil(Node node, int level)
        {
            // Base Case
            if (node == null) return;

            // If this is the first node of its level
            if (max_level < level)
            {
                Console.WriteLine(" " + node.data);
                max_level = level;
            }

            // Recur for left and right subtrees
            leftViewUtil(node.left, level + 1);
            leftViewUtil(node.right, level + 1);
        }

        // A wrapper over leftViewUtil()
        //static void leftView()
        //{
        //    leftViewUtil(root, 1);
        //}
    }

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

//http://www.geeksforgeeks.org/print-left-view-binary-tree/
//Average Difficulty : 2.6/5.0
//Based on 86 vote(s)


/*
 * 
 * The left view contains all nodes that are first nodes in their levels. 
 * A simple solution is to do level order traversal and print the first node in every level.

The problem can also be solved using simple recursive traversal. 
 * 
 * 
 * Time Complexity: The function does a simple traversal of the tree, so the complexity is O(n).
 * 
 * 
 * ALGO::
 
 * 0. Set maxLevel = 0;
 * 1. Call a recurse function with node and level = 1;
 * 2. If level == maxLevel, print data and set maxLevel as Level.
 * 3. Recurse for left node and next level (i.e. level++)
 * 4. Recurse for right node and next level (i.e. level++)

 */
