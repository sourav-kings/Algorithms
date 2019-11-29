using System;

namespace Count_Of_Nodes_In_GivenRange_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();

            tree.root = new Node(10);
            tree.root.left = new Node(5);
            tree.root.right = new Node(50);
            tree.root.left.left = new Node(1);
            tree.root.right.left = new Node(40);
            tree.root.right.right = new Node(100);
            /* Let us constructed BST shown in above example
              10
            /    \
          5       50
         /       /  \
        1       40   100   */
            int l = 5;
            int h = 45;
            Console.WriteLine("Count of nodes between [" + l + ", "
                              + h + "] is " + tree.GetCount(tree.root,
                                                          l, h));
        }
    }


    class BinarySearchTree
    {
        // Root of BST
        internal Node root;

        // Constructor
        internal BinarySearchTree()
        {
            root = null;
        }

        // Returns count of nodes in BST in 
        // range [low, high]
        internal int GetCount(Node node, int low, int high)
        {
            // Base Case
            if (node == null)
                return 0;

            // If current node is in range, then 
            // include it in count and recur for 
            // left and right children of it
            if (node.data >= low && node.data <= high)
                return 1 + this.GetCount(node.left, low, high) +
                    this.GetCount(node.right, low, high);

            // If current node is smaller than low, 
            // then recur for right child
            else if (node.data < low)
                return this.GetCount(node.right, low, high);

            // Else recur for left child
            else
                return this.GetCount(node.left, low, high);
        }
    }


    /* Class containing left and right child
    of current node and key value*/
    internal class Node
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
 * https://www.geeksforgeeks.org/count-bst-nodes-that-are-in-a-given-range/
 * (2.5 / 100)
 * 
 * Time complexity of the above program is O(h + k) 
 * where h is height of BST and k is number of nodes in given range.
 * 
 * 
 */
