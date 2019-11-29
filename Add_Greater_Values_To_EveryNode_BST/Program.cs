using System;

namespace Add_Greater_Values_To_EveryNode_BST
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

            tree.ModifyBST(tree.root);

            // print inoder tarversal of the modified BST
            tree.Inorder();
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
        
        // A wrapper over modifyBSTUtil()
        internal void ModifyBST(Node node)
        {
            Sum S = new Sum();
            this.ModifyBSTUtil(node, S);
        }

        // Recursive function to add all greater values in
        // every node
        void ModifyBSTUtil(Node node, Sum S)
        {
            // Base Case
            if (node == null)
                return;

            // Recur for right subtree    
            this.ModifyBSTUtil(node.right, S);

            // Now *sum has sum of nodes in right subtree, add
            // root->data to sum and update root->data
            S.sum = S.sum + node.data;
            node.data = S.sum;

            // Recur for left subtree
            this.ModifyBSTUtil(node.left, S);
        }

        // Inorder traversal of the tree
        internal void Inorder()
        {
            InorderUtil(this.root);
        }

        // Utility function for inorder traversal of
        // the tree
        void InorderUtil(Node node)
        {
            if (node == null)
                return;

            InorderUtil(node.left);
            Console.Write(node.data + " ");
            InorderUtil(node.right);
        }

        // adding new node 
        internal void Insert(int data)
        {
            this.root = this.InsertRec(this.root, data);
        }

        /* A utility function to insert a new node with 
        given data in BST */
        Node InsertRec(Node node, int data)
        {
            /* If the tree is empty, return a new node */
            if (node == null)
            {
                this.root = new Node(data);
                return this.root;
            }

            /* Otherwise, recur down the tree */
            if (data <= node.data)
            {
                node.left = this.InsertRec(node.left, data);
            }
            else
            {
                node.right = this.InsertRec(node.right, data);
            }
            return node;
        }


    }

    // This class initialises the value of sum to 0
    public class Sum
    {
        internal int sum = 0;
    }
    // A binary tree node
    internal class Node
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
 * https://www.geeksforgeeks.org/add-greater-values-every-node-given-bst/
 * 
 * A simple method for solving this is to find sum of all greater values for every node. 
 * This method would take O(n^2) time.
 * 
 * We can do it using a single traversal. The idea is to use following BST property. 
 * If we do reverse Inorder traversal of BST, we get all nodes in decreasing order. 
 * We do reverse Inorder traversal and keep track of the sum of all nodes visited so far, 
 * we add this sum to every node.
 */
