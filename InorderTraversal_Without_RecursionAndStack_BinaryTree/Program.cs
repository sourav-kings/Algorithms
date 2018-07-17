using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InorderTraversal_Without_RecursionAndStack_BinaryTree
{
    class Program
    {
        static tNode root;
        static void Main(string[] args)
        {

            /* Constructed binary tree is
                    1
                  /   \
                 2      3
               /  \      \
             4     5      6
             */

            
            root = new tNode(1);
            root.left = new tNode(2);
            root.right = new tNode(3);
            root.left.left = new tNode(4);
            root.left.right = new tNode(5);
            root.right.right = new tNode(6);

            //MorrisTraversal(root);

            MorrisTraversal_test(root); // testing in progress, not passed yet.

        }

        private static void MorrisTraversal_test(tNode root)
        {
            tNode current, temp;

            if (root == null)
                return;

            current = root;
            while (current != null)
            {
                if (current.left != null)
                {
                    /* Find the inorder predecessor of current */
                    temp = current.left;
                    while (temp.right != null && temp.right != current)
                        temp = temp.right;

                    /* Make current as right child of its inorder predecessor */
                    /* when the predecessor is NOT set*/
                    if (temp.right == null)
                    {
                        temp.right = current;
                        current = current.left;
                    }

                    /* Revert the changes made in if part to restore the 
                       original tree i.e.,fix the right child of predecssor*/
                    /* when the predecessor is already set*/
                    else
                    {
                        temp.right = null;
                        Console.Write(current.data + " ");
                        current = current.right;
                    }   /* End of if condition current->left == NULL*/
                }
                else
                {
                    Console.Write(current.data + " ");
                    current = current.right;
                } /* End of if condition pre->right == NULL */

            } /* End of while */
        }

        /* Function to traverse binary tree without recursion and 
        without stack */
        static void MorrisTraversal(tNode root)
        {
            tNode current, pre;

            if (root == null)
                return;

            current = root;
            while (current != null)
            {
                if (current.left == null)
                {
                    Console.Write(current.data + " ");
                    current = current.right;
                }
                else
                {
                    /* Find the inorder predecessor of current */
                    pre = current.left;
                    while (pre.right != null && pre.right != current)
                        pre = pre.right;

                    /* Make current as right child of its inorder predecessor */
                    /* when the predecessor is NOT set*/
                    if (pre.right == null)
                    {
                        pre.right = current;
                        current = current.left;
                    }

                    /* Revert the changes made in if part to restore the 
                       original tree i.e.,fix the right child of predecssor*/
                    /* when the predecessor is already set*/
                    else
                    {
                        pre.right = null;
                        Console.Write(current.data + " ");
                        current = current.right;
                    }   /* End of if condition pre->right == NULL */

                } /* End of if condition current->left == NULL*/

            } /* End of while */

        }

        /* A binary tree tNode has data, pointer to left child
         and a pointer to right child */
        class tNode
        {
            public int data;
            public tNode left, right;

            public tNode(int item)
            {
                data = item;
                left = right = null;
            }
        }
    }
}

//https://www.youtube.com/watch?v=wGXB9OWhPTg ( first 7 mins are enough to recall)
/*
 * In Inorder Traversal, we travel left subtree first and then right subtree.
 * 
 * Why we need Recursion or Stack?
 *  --  beacuse when we travel downwards in left subtree, 
 *      we need a way to return back to parent.
 *      
 *  What Morris Traversal does?
 *      It sets up a Inorder Predecessor. i.e. a link between current node
 *      and it's parent, so that we can go back.
 *      
 *  Steps?
 *      For a current root node, 
 *      if left child does NOT exist, then print current
 *      and set right child as current.
 *      
 *      if left child exist, keep moving to the right of the left child 
 *      until 
 *      it's null (this node is the Inorder Predecessor of root), or
 *      it connects back to root.
 *      
 *      So, establish the temp link i.e. set this node's right as root.
 *          (in order to have a way to come back to this root, once we're 
 *          done with the left subtree & also remove this link).
 *      And, set left child as current.
 */


//http://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion-and-without-stack/
//Average Difficulty : 4.2/5.0
//Based on 193 vote(s)

/*
 Using Morris Traversal, we can traverse the tree without using stack and recursion. 
 The idea of Morris Traversal is based on Threaded Binary Tree. In this traversal, 
 we first create links to Inorder successor and print the data using these links, 
 and finally revert the changes to restore original tree.

 Although the tree is modified through the traversal, it is reverted back to its original shape after the completion. 
 Unlike Stack based traversal, no extra space is required for this traversal.


    ALGO::

    1. Initialize current as root 
    2. While current is not NULL
       If current does not have left child
          a) Print current’s data
          b) Go to the right, i.e., current = current->right
       Else
          a) Set right child of the rightmost 
             node in current's left subtree as current.
          b) Go to this left child, i.e., current = current->left
*/


    /*
     * Setting Predecessor
     * 
     * 
     */
