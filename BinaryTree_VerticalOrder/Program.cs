using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree_VerticalOrder
{
    class Program
    {

        /*
                           1
                        /    \
                       2      3
                      / \    / \
                     4   5  6   7
                             \   \
                              8   9 
               
			  
                The output of print this tree vertically will be:
                4
                2
                1 5 6
                3 8
                7
                9 
         */
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
            //VerticalOrder(root);
            VerticalOrder_Faster(root);
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


        // The main function to print vertical oder of a binary tree
        // with given root
        static void VerticalOrder_Faster(Node root)
        {
            // Create a map and store vertical oder in map using
            // function getVerticalOrder()
            Dictionary<int, List<int>> m = new Dictionary<int, List<int>>();
            int hd = 0;
            GetVerticalOrder(root, hd, m);

            // Traverse the map and print nodes at every horigontal
            // distance (hd)
            IEnumerator dasd = m.Values.GetEnumerator();
            while (dasd.MoveNext())
            {
                List<int> list = (List<int>)dasd.Current;
                list.ForEach(x => Console.Write(x.ToString() + " "));
                Console.WriteLine();
            }
        }

        // Utility function to store vertical order in map 'm'
        // 'hd' is horizontal distance of current node from root.
        // 'hd' is initially passed as 0
        static void GetVerticalOrder(Node root, int hd,
                                    Dictionary<int, List<int>> m)
        {
            // Base case
            if (root == null)
                return;

            //get the vector list at 'hd'
            List<int> get = (!m.ContainsKey(hd)) ? null : m[hd]; 

            // Store current node in map 'm'
            if (get == null)
            {
                get = new List<int>();
                get.Add(root.data);
            }
            else
                get.Add(root.data);

            m[hd] = get;

            // Store nodes in left subtree
            GetVerticalOrder(root.left, hd - 1, m);

            // Store nodes in right subtree
            GetVerticalOrder(root.right, hd + 1, m);
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

/*
 * Set 1 - time complexity can become O(n*n).
 * https://www.geeksforgeeks.org/print-binary-tree-vertical-order/
 * (3 / 150)
 * Time complexity of above algorithm is O(w*n) 
 * In worst case, consider a complete tree, time complexity can become O(n*n).
 * 
 * 
 * Set 2 - time complexity can become O(nLogn).
 * (Hashmap based Method)
 * https://www.geeksforgeeks.org/print-binary-tree-vertical-order-set-2/
 * (3 / 200)
 */
