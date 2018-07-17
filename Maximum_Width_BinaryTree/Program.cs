using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_Width_BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Constructed bunary tree is:
                  1
                /  \
               2    3
              / \    \
             4   5    8
                     / \
                    6   7 */
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.right = new Node(8);
            root.right.right.left = new Node(6);
            root.right.right.right = new Node(7);

            Console.WriteLine("Maximum width is " +
                               GetMaxWidth(root));


            Console.WriteLine("Maximum width is " +
                               MaxWidth_queue(root));
            
        }

        /* Function to get the maximum width of a binary tree*/
        static int GetMaxWidth(Node node)
        {
            int maxWidth = 0;
            int width;
            int h = Height(node);
            int i;

            /* Get width of each level and compare 
               the width with maximum width so far */
            for (i = 1; i <= h; i++)
            {
                width = GetWidth(node, i);
                maxWidth = Math.Max(width, maxWidth);
            }

            return maxWidth;
        }

        // A function that fills count array with count of nodes at every
        // level of given binary tree
        static int GetWidth(Node node, int level)
        {
            if (node == null)
                return 0;

            if (level == 1)
                return 1;
            else if (level > 1)
                return GetWidth(node.left, level - 1)
                        + GetWidth(node.right, level - 1);
            return 0;
        }

        /* UTILITY FUNCTIONS */

        /* Compute the "height" of a tree -- the number of
         nodes along the longest path from the root node
         down to the farthest leaf node.*/
        static int Height(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                /* compute the height of each subtree */
                int lHeight = Height(node.left);
                int rHeight = Height(node.right);

                /* use the larger one */
                return (lHeight > rHeight) ? (lHeight + 1) : (rHeight + 1);
            }
        }








        // Function to find the maximum width of the tree
        // using level order traversal
        static int MaxWidth_queue(Node root)
        {
            // Base case
            if (root == null)
                return 0;

            // Initialize result
            int result = 0;

            // Do Level order traversal keeping track of number
            // of nodes at every level.
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Any())
            {
                // Get the size of queue when the level order
                // traversal for one level finishes
                int count = q.Count();

                // Update the maximum node count value
                result = Math.Max(count, result);

                // Iterate for all the nodes in the queue currently
                while (count>0)
                {
                    // Dequeue an node from queue
                    Node temp = q.Dequeue();

                    // Enqueue left and right children of
                    // dequeued node
                    if (temp.left != null)
                        q.Enqueue(temp.left);
                    if (temp.right != null)
                        q.Enqueue(temp.right);

                    count--;
                }
            }

            return result;
        }
    }

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
}

/*
 * Use "Level Order Traversal", both recursive and Queue based methods.


    //http://www.geeksforgeeks.org/maximum-width-of-a-binary-tree/

    //Average Difficulty : 2.5/5.0
    //Based on 106 vote(s)

*/

/*

    Given a binary tree, write a function to get the maximum width of the given tree. Width of a tree is maximum of widths of all levels.

    Let us consider the below example tree.

         1
        /  \
       2    3
     /  \     \
    4    5     8 
              /  \
             6    7
    For the above tree,
    width of level 1 is 1,
    width of level 2 is 2,
    width of level 3 is 3
    width of level 4 is 2.

    So the maximum width of the tree is 3.


 */



/*
 * Method 1 (Using Level Order Traversal)
 * --------------------------------------------
This method mainly involves two functions. One is to count nodes at a given level (getWidth), 
and other is to get the maximum width of the tree(getMaxWidth). 
getMaxWidth() makes use of getWidth() to get the width of all levels starting from root.


getMaxWidth(tree)
maxWdth = 0
for i = 1 to height(tree)
  width =   getWidth(tree, i);
  if(width > maxWdth) 
      maxWdth  = width
return width

getWidth(tree, level)
if tree is NULL then return 0;
if level is 1, then return 1;  
else if level greater than 1, then
    return getWidth(tree->left, level-1) + 
    getWidth(tree->right, level-1);


    Time Complexity: O(n^2) in the worst case.








    Method 2 (Using Level Order Traversal with Queue)
  --------------------------------------------
In this method we store all the child nodes at the current level in the queue and 
then count the total number of nodes after the level order traversal for a particular level is completed. 
Since the queue now contains all the nodes of the next level, 
we can easily find out the total number of nodes in the next level by finding the size of queue. 
We then follow the same procedure for the successive levels. We store and update the maximum number of nodes found at each level.
Time Complexity: O(n^2) in the worst case.




    Method 3 (Using Preorder Traversal)
    --------------------------------------------
In this method we create a temporary array count[] of size equal to the height of tree. We initialize all values in count as 0. 
We traverse the tree using preorder traversal and fill the entries in count so that the count array contains count of nodes at each level in Binary Tree.
Time Complexity: O(n)




     */
