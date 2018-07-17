using System;

namespace BinaryTree_VerticalOrder
{
    class Program
    {
        static Node root;
        static Values val = new Values();
        static void Main(string[] args)
        {
            /* Let us construct the tree shown in above diagram */
            root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.left = new Node(6);
            root.right.right = new Node(7);
            root.right.left.right = new Node(8);
            root.right.right.right = new Node(9);

            Console.WriteLine("vertical order traversal is :");
            VerticalOrder(root);
        }


        // The main function that prints a given binary tree in
        // vertical order
        static void VerticalOrder(Node node)
        {
            // Find min and max distances with resepect to root
            FindMinMax(node, val, val, 0);

            // Iterate through all possible vertical lines starting
            // from the leftmost line and print nodes line by line
            for (int line_no = val.min; line_no <= val.max; line_no++)
            {
                PrintVerticalLine(node, line_no, 0);
                Console.WriteLine("");
            }
        }


        // A utility function to print all nodes on a given line_no.
        // hd is horizontal distance of current node with respect to root.
        static void PrintVerticalLine(Node node, int line_no, int hd)
        {
            // Base case
            if (node == null)
                return;

            // If this node is on the given line number
            if (hd == line_no)
                Console.Write(node.data + " ");

            // Recur for left and right subtrees
            PrintVerticalLine(node.left, line_no, hd - 1);
            PrintVerticalLine(node.right, line_no, hd + 1);
        }


        // A utility function to find min and max distances with respect
        // to root.
        static void FindMinMax(Node node, Values min, Values max, int hd)
        {
            // Base case
            if (node == null)
                return;

            // Update min and max
            if (hd < min.min)
                min.min = hd;
            else if (hd > max.max)
                max.max = hd;

            // Recur for left and right subtrees
            FindMinMax(node.left, min, max, hd - 1);
            FindMinMax(node.right, min, max, hd + 1);
        }




    }

    // A binary tree node
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

    class Values
    {
        public int max, min;
    }

}
