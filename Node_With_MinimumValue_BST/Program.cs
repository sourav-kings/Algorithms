using System;

namespace Node_With_MinimumValue_BST
{
    class Program
    {
        static void Main(string[] args)
        {

            BinaryTree tree = new BinaryTree();
            Node root = null;
            root = tree.Insert(root, 4);
            tree.Insert(root, 2);
            tree.Insert(root, 1);
            tree.Insert(root, 3);
            tree.Insert(root, 6);
            tree.Insert(root, 5);

            Console.WriteLine("The minimum value of BST is " + tree.Minvalue(root));
        }
    }


    class BinaryTree
    {
        internal Node head;

        /* Given a non-empty binary search tree,  
         return the minimum data value found in that 
         tree. Note that the entire tree does not need 
         to be searched. */
        internal int Minvalue(Node node)
        {
            Node current = node;

            /* loop down to find the leftmost leaf */
            while (current.left != null)
            {
                current = current.left;
            }
            return (current.data);
        }
        

        /* Given a binary search tree and a number, 
         inserts a new node with the given number in 
         the correct place in the tree. Returns the new 
         root pointer which the caller should then use 
         (the standard trick to avoid using reference 
         parameters). */
        internal Node Insert(Node node, int data)
        {

            /* 1. If the tree is empty, return a new,     
             single node */
            if (node == null)
            {
                return (new Node(data));
            }
            else
            {

                /* 2. Otherwise, recur down the tree */
                if (data <= node.data)
                {
                    node.left = Insert(node.left, data);
                }
                else
                {
                    node.right = Insert(node.right, data);
                }

                /* return the (unchanged) node pointer */
                return node;
            }
        }

    }

    // A binary tree node
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
 * https://www.geeksforgeeks.org/find-the-minimum-element-in-a-binary-search-tree/
 */
