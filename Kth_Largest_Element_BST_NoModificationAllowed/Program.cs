using System;

namespace Kth_Largest_Element_BST_NoModificationAllowed
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();

            /* Let us create following BST
                  50
               /     \
              30      70
             /  \    /  \
           20   40  60   80 */
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            for (int i = 1; i <= 7; i++)
            {
                tree.KthLargest(i);
            }
        }
    }

    public class BinarySearchTree
    {
        // Root of BST
        internal Node root;

        // Constructor
        internal BinarySearchTree()
        {
            root = null;
        }

        // function to insert nodes
        public void Insert(int data)
        {
            this.root = this.InsertRec(this.root, data);
        }

        /* A utility function to insert a new node 
        with given key in BST */
        Node InsertRec(Node node, int data)
        {
            /* If the tree is empty, return a new node */
            if (node == null)
            {
                this.root = new Node(data);
                return this.root;
            }

            if (data == node.data)
            {
                return node;
            }

            /* Otherwise, recur down the tree */
            if (data < node.data)
            {
                node.left = this.InsertRec(node.left, data);
            }
            else
            {
                node.right = this.InsertRec(node.right, data);
            }
            return node;
        }

        // class that stores the value of count
        public class Count
        {
            internal int c = 0;
        }

        // utility function to find kth largest no in 
        // a given tree
        void KthLargestUtil(Node node, int k, Count C)
        {
            // Base cases, the second condition is important to
            // avoid unnecessary recursive calls
            if (node == null || C.c >= k)
                return;

            // Follow reverse inorder traversal so that the
            // largest element is visited first
            this.KthLargestUtil(node.right, k, C);

            // Increment count of visited nodes
            C.c++;

            // If c becomes k now, then this is the k'th largest 
            if (C.c == k)
            {
                Console.WriteLine(k + "th largest element is " +
                                                     node.data + "\n");
                return;
            }

            // Recur for left subtree
            this.KthLargestUtil(node.left, k, C);
        }

        // Method to find the kth largest no in given BST
        internal void KthLargest(int k)
        {
            Count c = new Count(); // object of class count
            this.KthLargestUtil(this.root, k, c);
        }

    }


    class Node
    {
        internal int data;
        internal Node left, right;

        internal Node(int d)
        {
            data = d;
            left = right = null;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/kth-largest-element-in-bst-when-modification-to-bst-is-not-allowed/
 * 
 * In this post, a method is discussed that takes O(h + k) time. This method doesn’t require any change to BST.
 * The code first traverses down to the rightmost node which takes O(h) time, 
 * then traverses k elements in O(k) time. Therefore overall time complexity is O(h + k).
 * 
 * The idea is to do reverse inorder traversal of BST. 
 * The reverse inorder traversal traverses all nodes in decreasing order. 
 * While doing the traversal, we keep track of count of nodes visited so far. 
 * When the count becomes equal to k, we stop the traversal and print the key.
 */
