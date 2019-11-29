using System;

namespace DoubleTree_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Constructed binary tree is
                  1
                /   \
               2     3
             /  \
            4    5
            */
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("Original tree is : ");
            tree.PrintInorder(tree.root);
            tree.DoubleTree(tree.root);
            Console.WriteLine("");
            Console.WriteLine("Inorder traversal of double tree is : ");
            tree.PrintInorder(tree.root);
        }
    }



    class BinaryTree
    {
        internal Node root;

        /* Function to convert a tree to double tree */
        internal void DoubleTree(Node node)
        {
            Node oldleft;

            if (node == null)
                return;

            /* do the subtrees */
            DoubleTree(node.left);
            DoubleTree(node.right);

            /* duplicate this node to its left */
            oldleft = node.left;
            node.left = new Node(node.data);
            node.left.left = oldleft;
        }

        /* Given a binary tree, print its nodes in inorder*/
        internal void PrintInorder(Node node)
        {
            if (node == null)
                return;
            PrintInorder(node.left);
            Console.Write(node.data + " ");
            PrintInorder(node.right);
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
/*
 * https://www.geeksforgeeks.org/double-tree/
 * 
 * Write a program that converts a given tree to its Double tree. 
 * To create Double tree of the given tree, create a new duplicate for each node, 
 * and insert the duplicate as the left child of the original node.
 * 
 * So the tree…

        2
       / \
      1   3
    is changed to…

           2
          / \
         2   3
        /   /
       1   3
      /
     1



    Algorithm:
        Recursively convert the tree to double tree in postorder fashion. 
        For each node, first convert the left subtree of the node, then right subtree, 
        finally create a duplicate node of the node and fix the left child of the node and left child of left child.
 */
