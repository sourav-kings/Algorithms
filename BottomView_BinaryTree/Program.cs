using System;
using System.Collections;
using System.Collections.Generic;

namespace BottomView_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(20);
            root.left = new Node(8);
            root.right = new Node(22);
            root.left.left = new Node(5);
            root.left.right = new Node(3);
            root.right.left = new Node(4);
            root.right.right = new Node(25);
            root.left.right.left = new Node(10);
            root.left.right.right = new Node(14);
            Tree tree = new Tree(root);
            Console.WriteLine("Bottom view of the given binary tree:");
            tree.BottomView();
        }

        // Tree node class
        class Node
        {
            public int data; //data of the node
            public int hd; //horizontal distance of the node
            public Node left, right; //left and right references

            // Constructor of tree node
            public Node(int key)
            {
                data = key;
                hd = int.MaxValue;
                left = right = null;
            }
        }

        //Tree class
        class Tree
        {
            Node root; //root node of tree

            // Default constructor
            public Tree() { }

            // Parameterized tree constructor
            public Tree(Node node)
            {
                root = node;
            }

            // Method that prints the bottom view.
            public void BottomView()
            {
                if (root == null)
                    return;

                // Initialize a variable 'hd' with 0 for the root element.
                int hd = 0;

                // TreeMap which stores key value pair sorted on key value
                SortedDictionary<int, int> map = new SortedDictionary<int, int>();

                // Queue to store tree nodes in level order traversal
                Queue<Node> queue = new Queue<Node>();

                // Assign initialized horizontal distance value to root
                // node and add it to the queue.
                root.hd = hd;
                queue.Enqueue(root);

                // Loop until the queue is empty (standard level order loop)
                while (queue.Count != 0)
                {
                    Node temp = queue.Dequeue();

                    // Extract the horizontal distance value from the
                    // dequeued tree node.
                    hd = temp.hd;

                    // Put the dequeued tree node to TreeMap having key
                    // as horizontal distance. Every time we find a node
                    // having same horizontal distance we need to replace
                    // the data in the map.
                    map[hd] = temp.data;

                    // If the dequeued node has a left child add it to the
                    // queue with a horizontal distance hd-1.
                    if (temp.left != null)
                    {
                        temp.left.hd = hd - 1;
                        queue.Enqueue(temp.left);
                    }
                    // If the dequeued node has a left child add it to the
                    // queue with a horizontal distance hd+1.
                    if (temp.right != null)
                    {
                        temp.right.hd = hd + 1;
                        queue.Enqueue(temp.right);
                    }
                }


                IEnumerator dasd = map.Values.GetEnumerator();
                while(dasd.MoveNext())
                    Console.Write(dasd.Current + " ");
            }
        }
    }
}

/*
 * https://www.geeksforgeeks.org/bottom-view-binary-tree/
 * 
 *  Bottom View of a Binary Tree
    Given a Binary Tree, we need to print the bottom view from left to right. 
    A node x is there in output if x is the bottommost node at its horizontal distance. 
    Horizontal distance of left child of a node x is equal to horizontal distance of x minus 1, 
    and that of right child is horizontal distance of x plus 1


                      20
                    /    \
                  8       22
                /   \    /   \
              5      3 4     25
                    / \      
                  10    14 

    For the above tree the output should be 5, 10, 4, 14, 25.

    If there are multiple bottom-most nodes for a horizontal distance from root, then print the later one in level traversal. 

 */
