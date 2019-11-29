using System;

namespace Tree_Isomorphism_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            // Let us create trees shown in above diagram
            tree.root1 = new Node(1);
            tree.root1.left = new Node(2);
            tree.root1.right = new Node(3);
            tree.root1.left.left = new Node(4);
            tree.root1.left.right = new Node(5);
            tree.root1.right.left = new Node(6);
            tree.root1.left.right.left = new Node(7);
            tree.root1.left.right.right = new Node(8);

            tree.root2 = new Node(1);
            tree.root2.left = new Node(3);
            tree.root2.right = new Node(2);
            tree.root2.right.left = new Node(4);
            tree.root2.right.right = new Node(5);
            tree.root2.left.right = new Node(6);
            tree.root2.right.right.left = new Node(8);
            tree.root2.right.right.right = new Node(7);

            if (tree.IsIsomorphic(tree.root1, tree.root2) == true)
                Console.WriteLine("Yes");
            else
                    Console.WriteLine("No");
        }
    }

    class BinaryTree
    {
        internal Node root1, root2;

        /* Given a binary tree, print its nodes in reverse level order */
        internal bool IsIsomorphic(Node n1, Node n2)
        {
            // Both roots are NULL, trees isomorphic by definition
            if (n1 == null && n2 == null)
                return true;

            // Exactly one of the n1 and n2 is NULL, trees not isomorphic
            if (n1 == null || n2 == null)
                return false;

            if (n1.data != n2.data)
                return false;

            // There are two possible cases for n1 and n2 to be isomorphic
            // Case 1: The subtrees rooted at these nodes have NOT been 
            // "Flipped". 
            // Both of these subtrees have to be isomorphic.
            // Case 2: The subtrees rooted at these nodes have been "Flipped"
            return (IsIsomorphic(n1.left, n2.left) && IsIsomorphic(n1.right, n2.right))
            || (IsIsomorphic(n1.left, n2.right) && IsIsomorphic(n1.right, n2.left));
        }
    }

    class Node
    {
        internal int data;
        internal Node left, right;

        internal Node(int item)
        {
            data = item;
            left = right;
        }
    }
}
/*
 * Tree Isomorphism Problem
     * Write a function to detect if two trees are isomorphic. 
     * Two trees are called isomorphic if one of them can be obtained from other by a series of flips, 
     * i.e. by swapping left and right children of a number of nodes. 
     * Any number of nodes at any level can have their children swapped. 
     * Two empty trees are isomorphic.
     * 
     * Time Complexity: The above solution does a traversal of both trees. 
     * So time complexity is O(m + n) where m and n are number of nodes in given trees.
 */
