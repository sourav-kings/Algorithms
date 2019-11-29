using System;

namespace Remove_Keys_Outside_GivenRange_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();

            tree.Insert(6);
            tree.Insert(-13);
            tree.Insert(14);
            tree.Insert(-8);
            tree.Insert(15);
            tree.Insert(13);
            tree.Insert(7);

            Console.WriteLine("Inorder traversal of the given tree is: ");
            tree.Inorder();

            tree.RemoveOutsideRange(tree.root, -10, 13);

            Console.WriteLine("\nInorder traversal of the modified tree is: ");
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


        // Resmoves all nodes having value outside the given range and returns the root
        // of modified tree
        internal Node RemoveOutsideRange(Node node, int min, int max)
        {
            // Base Case
            if (node == null)
                return null;

            // First fix the left and right subtrees of root
            node.left = RemoveOutsideRange(node.left, min, max);
            node.right = RemoveOutsideRange(node.right, min, max);

            // Now fix the root.  There are 2 possible cases for toot
            // 1.a) Root's key is smaller than min value (root is not in range)
            if (node.data < min)
            {
                Node rChild = node.right;
                node = null;
                return rChild;
            }
            // 1.b) Root's key is greater than max value (root is not in range)
            if (node.data > max)
            {
                Node lChild = node.left;
                node = null;
                return lChild;
            }
            // 2. Root is in range
            return node;
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
 * https://www.geeksforgeeks.org/remove-bst-keys-outside-the-given-range/
 * 3.5 / 100
 */
