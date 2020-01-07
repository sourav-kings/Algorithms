using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level_Order_Tree_Traversal
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

            Console.WriteLine("Level order traversal of binary tree is ");
            printLevelOrder();        // O(n^2)
            Console.WriteLine();
            printLevelOrderFaster();    // O(n)
        }

        /* function to print level order traversal of tree*/
        static void printLevelOrder()
        {
            int h = height(root);
            int i;
            for (i = 1; i <= h; i++)
                printGivenLevel(root, i);
        }

        /* Compute the "height" of a tree -- the number of
        nodes along the longest path from the root node
        down to the farthest leaf node.*/
        static int height(Node root)
        {
            if (root == null)
                return 0;
            else
            {
                /* compute  height of each subtree */
                int lheight = height(root.left);
                int rheight = height(root.right);

                /* use the larger one */
                return Math.Max(lheight, rheight) + 1;

                //if (lheight > rheight)
                //    return (lheight + 1);
                //else return (rheight + 1);

            }
        }

        /* Print nodes at the given level */
        static void printGivenLevel(Node root, int level)
        {
            if (root == null)
                return;
            if (level == 1)
                Console.Write(root.data + " ");
            else if (level > 1)
            {
                printGivenLevel(root.left, level - 1);
                printGivenLevel(root.right, level - 1);
            }
        }



        /* Given a binary tree. Print its nodes in level order
        using array for implementing queue 
        Time Complexity :: O(n) 
        */
        static void printLevelOrderFaster()
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                Node tempNode = queue.Dequeue();
                Console.Write(tempNode.data + " ");

                /*Enqueue left child */
                if (tempNode.left != null)
                    queue.Enqueue(tempNode.left);

                /*Enqueue right child */
                if (tempNode.right != null)
                    queue.Enqueue(tempNode.right);
            }
        }

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


//http://www.geeksforgeeks.org/level-order-tree-traversal/

//Average Difficulty : 2.5/5.0
//Based on 450+ vote(s)


    /*
     * Two methods
     * 
     * Using Recursion
     * ---------------
     * 1.  Get height.
     * 2.  loop for each int of height and call function with node and index
     * 3.  Check base case of node ==  null
     * 4.  if level==1, print node
     * 5.  if level > 1, recur for left node and (level - 1) and repeat for right node.
     * 
     * 
     * Using Queue (no recusion)
     * -------------------------
     * 0.
     * 1. Declare a Queue object.
     * 2. Add node to Queue.
     * 3. Loop until Queue has no data
     * 4.       Dequeue node and print data
     * 5.       If left is not null, queue left node. Repeat from right.
     
     */
