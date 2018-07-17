using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kth_Smallest_Element_BST
{
    class Program
    {


        static void Main(string[] args)
        {
            /* Let us create following BST
                  50
               /     \
              30      70
             /  \    /  \
           20   40  60   80 */
            Node root = null;
            root = insert(root, 50);
            insert(root, 30);
            insert(root, 20);
            insert(root, 40);
            insert(root, 70);
            insert(root, 60);
            insert(root, 80);

            for (int k = 1; k <= 5; k++)
            {
                Console.WriteLine(k + " smallest Element is :- " +  KSmallestUsingMorris(root, k) + " ");
                //Console.Write(kthSmallestUsingStack(root, k) + " ");                
            }

            Console.WriteLine("\n \n");

            for (int k = 1; k <= 5; k++)
            {
                Console.WriteLine(k + " smallest Element is :- " + kthSmallestUsingStack2(root, k) + " ");
                //Console.Write(kthSmallestUsingStack(root, k) + " ");                
            }
        }

        // A utility function to insert a new node with given key in BST /
        static Node insert(Node node, int key)
        {
            // If the tree is empty, return a new node /
            if (node == null)
                return new Node(key);

            // Otherwise, recur down the tree /
            if (key < node.key)
                node.left = insert(node.left, key);
            else if (key > node.key)
                node.right = insert(node.right, key);

            // return the (unchanged) node pointer /
            return node;
        }
        // A function to find
        static int KSmallestUsingMorris(Node root, int k)
        {
            // Count to iterate over elements till we
            // get the kth smallest number
            int count = 0;

            int ksmall = int.MinValue; // store the Kth smallest
            Node curr = root; // to store the current node

            while (curr != null)
            {
                // Like Morris traversal if current does
                // not have left child rather than printing
                // as we did in inorder, we will just
                // increment the count as the number will
                // be in an increasing order
                if (curr.left == null)
                {
                    //count++;

                    // if count is equal to K then we found the
                    // kth smallest, so store it in ksmall
                    if (++count == k)
                        ksmall = curr.key;

                    // go to current's right child
                    curr = curr.right;
                }
                else
                {
                    // we create links to Inorder Successor and
                    // count using these links
                    Node pre = curr.left;
                    while (pre.right != null && pre.right != curr)
                        pre = pre.right;

                    // building links
                    if (pre.right == null)
                    {
                        //link made to Inorder Successor
                        pre.right = curr;
                        curr = curr.left;
                    }

                    // While breaking the links in so made temporary
                    // threaded tree we will check for the K smallest
                    // condition
                    else
                    {
                        // Revert the changes made in if part (break link
                        // from the Inorder Successor)
                        pre.right = null;

                        //count++;

                        // If count is equal to K then we found
                        // the kth smallest and so store it in ksmall
                        if (++count == k)
                            ksmall = curr.key;

                        curr = curr.right;
                    }
                }
            }
            return ksmall; //return the found value
        }

        static int kthSmallestUsingStack(Node root, int k)
        {
            Stack<Node> stack = new Stack<Node>();            
            int result = 0;

            while (stack.Count != 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    Node t = stack.Pop();
                    k--;
                    if (k == 0)
                        result = t.key;
                    root = t.right;
                }
            }

            return result;
        }

        static int kthSmallestUsingStack2(Node root, int k)
        {
            Stack<Node> stack = new Stack<Node>();
            int result = 0;

            if (root == null)
                return 0;


            while (stack.Count != 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    Node t = stack.Pop();
                    k--;
                    if (k == 0)
                        result = t.key;
                    root = t.right;
                }
            
            }

            return result;
        }
    }

    class Node
    {
        public int key;
        public Node left, right;

        public Node(int item)
        {
            key = item;
            left = right = null;
        }
    }
}




/*
 * http://www.geeksforgeeks.org/find-k-th-smallest-element-in-bst-order-statistics-in-bst/
 
    Average Difficulty : 3.4/5.0
Based on 95 vote(s)

     */

    /*
     * Stack Method (No Recursion)
     * ----------------------------
     * 
     */
      *







/*
 * Method 1: Using Inorder Traversal.

Inorder traversal of BST retrieves elements of tree in the sorted order. 
The inorder traversal uses stack to store to be explored nodes of tree (threaded tree avoids stack and recursion for traversal, see this post). 
The idea is to keep track of popped elements which participate in the order statics. Hypothetical algorithm is provided below,

Time complexity: O(n) where n is total nodes in tree..
 */
