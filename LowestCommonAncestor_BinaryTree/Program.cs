using System;

namespace LowestCommonAncestor_BinaryTree
{
    class Program
    {
        // Root of the Binary Tree
        static Node root;
        static bool v1 = false, v2 = false;

        static void Main(string[] args)
        {
            root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.left = new Node(6);
            root.right.right = new Node(7);

            Node lca = FindLCA(4, 5);
            if (lca != null)
                Console.WriteLine("LCA(4, 5) = " + lca.data);
            else
                Console.WriteLine("Keys are not present");


            Console.WriteLine("\n");
            lca = FindLCA(4, 10);
            if (lca != null)
                Console.WriteLine("LCA(4, 10) = " + lca.data);
            else
                Console.WriteLine("Keys are not present");


            Console.WriteLine("\n");
            lca = FindLCA(4, 6);
            if (lca != null)
                Console.WriteLine("LCA(4, 6) = " + lca.data);
            else
                Console.WriteLine("Keys are not present");
        }

        private static Node FindLCA(int n1, int n2)
        {
            // Initialize n1 and n2 as not visited
            v1 = false;
            v2 = false;

            // Find lca of n1 and n2 using the technique discussed above
            Node lca = FindLCAUtil(root, n1, n2);

            // Return LCA only if both n1 and n2 are present in tree
            if (v1 && v2)
                return lca;

            // Else return NULL
            return null;
        }



        

        // This function returns pointer to LCA of two given
        // values n1 and n2.
        // v1 is set as true by this function if n1 is found
        // v2 is set as true by this function if n2 is found
        static Node FindLCAUtil(Node node, int n1, int n2)
        {
            // Base case
            if (node == null)
                return null;

            // If either n1 or n2 matches with root's key, report the presence
            // by setting v1 or v2 as true and return root (Note that if a key
            // is ancestor of other, then the ancestor key becomes LCA)
            if (node.data == n1)
            {
                v1 = true;
                return node;
            }
            if (node.data == n2)
            {
                v2 = true;
                return node;
            }

            // Look for keys in left and right subtrees
            Node left_lca = FindLCAUtil(node.left, n1, n2);
            Node right_lca = FindLCAUtil(node.right, n1, n2);

            // If both of the above calls return Non-NULL, then one key
            // is present in once subtree and other is present in other,
            // So this node is the LCA
            if (left_lca != null && right_lca != null)
                return node;

            // Otherwise check if left subtree or right subtree is LCA
            return left_lca ?? right_lca;
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
 * https://www.geeksforgeeks.org/lowest-common-ancestor-binary-tree-set-1/
 * 
 * 3.5 (300+)
 * 
 * Method 1 (By Storing root to n1 and root to n2 paths):
 * 
 * Method 2 (Using Single Traversal)
 *  The method 1 finds LCA in O(n) time, but requires three tree traversals plus extra spaces for path arrays.
 *  If we assume that the keys n1 and n2 are present in Binary Tree, we can find LCA 
 *  using single traversal of Binary Tree and without extra storage for path arrays.
 */
