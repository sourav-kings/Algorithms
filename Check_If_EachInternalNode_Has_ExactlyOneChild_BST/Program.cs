using System;

namespace Check_If_EachInternalNode_Has_ExactlyOneChild_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            int[] pre = new int[] { 8, 3, 5, 7, 6 };
            int size = pre.Length;
            if (tree.HasOnlyOneChild(pre, size) == true)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }

    // Check if each internal node of BST has only one child

    class BinaryTree
    {

        internal bool HasOnlyOneChild(int[] pre, int size)
        {
            int nextDiff, lastDiff;

            for (int i = 0; i < size - 1; i++)
            {
                nextDiff = pre[i] - pre[i + 1];
                lastDiff = pre[i] - pre[size - 1];
                if (nextDiff * lastDiff < 0)
                    return false;
            }
            return true;
        }
    }
}

/*
 * https://www.geeksforgeeks.org/check-if-each-internal-node-of-a-bst-has-exactly-one-child/
 * 
 * RULE - 
 *  In Preorder traversal, descendants (or Preorder successors) of every node appear after the node.
 * 
 * 
 * HOW TO SOLVE -
 *   if all internal nodes have only one child in a BST, 
 *   then all the descendants of every node are either smaller or larger than the node. 
 *   
 *   
 *   APPROACHES - 
 *      1st - Naive Method -  O(n) time complexity
 *      
 *      2nd - Approach 2
 *      
Since all the descendants of a node must either be larger or smaller than the node. We can do following for every node in a loop.
1. Find the next preorder successor (or descendant) of the node.
2. Find the last preorder successor (last element in pre[]) of the node.
3. If both successors are less than the current node, or both successors are greater than the current node, then continue. 
Else, return false.
 * 
 */
