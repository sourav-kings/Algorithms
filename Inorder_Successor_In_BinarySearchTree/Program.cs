using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inorder_Successor_In_BinarySearchTree
{
    /*In Binary Tree, Inorder successor of a node is the next node in Inorder traversal of the Binary Tree. 
      Inorder Successor is NULL for the last node in Inoorder traversal.
      In Binary Search Tree, Inorder Successor of an input node can also be defined as 
      the node with the smallest key greater than the key of input node. 
      So, it is sometimes important to find next node in sorted order.
    */
    class Program
    {
        static Node head;
        static void Main(string[] args)
        {
            Node root = null, temp = null, suc = null, suc2 = null, min = null;
            root = insert(root, 20);
            root = insert(root, 8);
            root = insert(root, 22);
            root = insert(root, 4);
            root = insert(root, 12);
            root = insert(root, 10);
            root = insert(root, 14);
            temp = root.left.right.right;
            //suc = inOrderSuccessor(root, temp);   //o(h) -- Method 1 (Uses Parent Pointer) 
            suc2 = inOrderSuccessor2(root, temp); //o(h) -- Method 2 (Search from root)  parent pointer is not needed
            if (suc != null)
            {
                Console.WriteLine("Inorder successor of " + temp.data +
                                                          " is " + suc.data);
                Console.WriteLine("Inorder successor of " + temp.data +
                                                          " is " + suc2.data);
            }
            else
            {
                Console.WriteLine("Inorder successor does not exist");
            }
        }

        /*   
             Given a binary search tree and a number, 
             inserts a new node with the given number in 
             the correct place in the tree. Returns the new 
             root pointer which the caller should then use 
             (the standard trick to avoid using reference parameters). 
        */
        static Node insert(Node node, int data)
        {

            /* 1. If the tree is empty, return a new,     
             single node */
            if (node == null)
            {
                return (new Node(data));
            }
            else
            {

                Node temp = null;

                /* 2. Otherwise, recur down the tree */
                if (data <= node.data)
                {
                    temp = insert(node.left, data);
                    node.left = temp;
                    temp.parent = node;

                }
                else
                {
                    temp = insert(node.right, data);
                    node.right = temp;
                    temp.parent = node;
                }

                /* return the (unchanged) node pointer */
                return node;
            }
        }

        static Node inOrderSuccessor(Node root, Node n)
        {

            // step 1 of the above algorithm 
            if (n.right != null)
            {
                return minValue(n.right);
            }

            // step 2 of the above algorithm
            Node p = n.parent;
            while (p != null && n == p.right)
            {
                n = p;
                p = p.parent;
            }
            return p;
        }

        static Node inOrderSuccessor2(Node root, Node n)
        {

            // step 1 of the above algorithm 
            if (n.right != null)
            {
                return minValue(n.right);
            }

            // step 2 of the above algorithm
            Node succ = null;

            // Start from root and search for successor down the tree
            //Travel down the tree, if a node’s data is greater than root’s data 
            //then go right side, otherwise go to left side.
            while (root != null)
            {
                if (n.data < root.data)
                {
                    succ = root;
                    root = root.left;
                }
                else if (n.data > root.data)
                    root = root.right;
                else
                    break;
            }

            return succ;
        }


        /* Given a non-empty binary search tree, return the minimum data  
         value found in that tree. Note that the entire tree does not need
         to be searched. */
        static Node minValue(Node node)
        {
            Node current = node;

            /* loop down to find the leftmost leaf */
            while (current.left != null)
            {
                current = current.left;
            }
            return current;
        }
    }

    class Node
    {
        public int data;
        public Node left, right, parent;

        public Node(int d)
        {
            data = d;
            left = right = parent = null;
        }
    }
}

//http://www.geeksforgeeks.org/inorder-successor-in-binary-search-tree/
//Average Difficulty : 2.8/5.0
//Based on 102 vote(s)


    /**/