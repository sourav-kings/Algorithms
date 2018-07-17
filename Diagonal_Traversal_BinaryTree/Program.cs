using System;
using System.Collections;
using System.Collections.Generic;

namespace Diagonal_Traversal_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(8);
            root.left = new Node(3);
            root.right = new Node(10);
            root.left.left = new Node(1);
            root.left.right = new Node(6);
            root.right.right = new Node(14);
            root.right.right.left = new Node(13);
            root.left.right.left = new Node(4);
            root.left.right.right = new Node(7);

            DiagonalPrint(root);
        }

        // Print diagonal traversal of given binary tree
        static void DiagonalPrint(Node root)
        {
            // create a map of vectors to store Diagonal elements
            Dictionary<int, List<int>> diagonalPrint = new Dictionary<int, List<int>>();
            DiagonalPrintUtil(root, 0, diagonalPrint);

            Console.WriteLine("Diagonal Traversal of Binnary Tree");
            IEnumerator dasd = diagonalPrint.Values.GetEnumerator();
            while (dasd.MoveNext())
            {
                List<int> list = (List<int>)dasd.Current;
                list.ForEach(x => Console.Write(x.ToString() + " "));
                Console.WriteLine();
            }

        }

        /* root - root of the binary tree
   d -  distance of current line from rightmost
        -topmost slope.
   diagonalPrint - HashMap to store Diagonal
                   elements (Passed by Reference) */
        static void DiagonalPrintUtil(Node root, int d,
                Dictionary<int, List<int>> diagonalPrint)
        {

            // Base case
            if (root == null)
                return;


            // get the list at the particular d value
            List<int> k = new List<int>();
            if (diagonalPrint.ContainsKey(d))
                k = diagonalPrint[d];

            k.Add(root.data);

            // Store all nodes of same line together as a vector
            diagonalPrint[d] = k;

            // Increase the vertical distance if left child
            DiagonalPrintUtil(root.left, d + 1, diagonalPrint);

            // Vertical distance remains same for right child
            DiagonalPrintUtil(root.right, d, diagonalPrint);
        }


    }
    // Tree node
    class Node
    {
        public int data;
        public Node left;
        public Node right;

        //constructor
        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }

}
/*
 * https://www.geeksforgeeks.org/diagonal-traversal-of-binary-tree/
 */
