using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correct_BST_By_Swapping_TwoNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *     Input Tree:
             10
            /  \
           5    8
          / \
         2   20

    In the above tree, nodes 20 and 8 must be swapped to fix the tree.  
    Following is the output tree
             10
            /  \
           5    20
          / \
         2   8
             */

            TreeNode root = new TreeNode(10);
            root.Right = new TreeNode(8);
            root.Left = new TreeNode(5);
            root.Left.Left = new TreeNode(2);
            root.Left.Right = new TreeNode(20);



            //TreeNode root = new TreeNode(6);
            //root.Left = new TreeNode(10);
            //root.Right = new TreeNode(2);
            //root.Left.Left = new TreeNode(1);
            //root.Left.Right = new TreeNode(3);
            //root.Right.Right = new TreeNode(12);
            //root.Right.Left = new TreeNode(7);


            //TreeNode root = new TreeNode(8);
            //root.Right = new TreeNode(20);
            //root.Left = new TreeNode(5);
            //root.Left.Left = new TreeNode(2);
            //root.Left.Right = new TreeNode(10);



            Console.WriteLine("InCorrect Bst Inorder traversal :");
            InOrder(root);
            //correctBST2(root);
            //CorrectBst(root);
            recoverTree(root);
            Console.WriteLine();
            Console.WriteLine("Corrected Bst Inorder traversal");
            InOrder(root);


            Console.WriteLine("\n");



            //TreeNode root = new TreeNode { Data = 6 }; 
            //root.Left = new TreeNode { Data = 10 }; 
            //root.Right = new TreeNode { Data = 2 };
            //root.Left.Left = new TreeNode { Data = 1 }; 
            //root.Left.Right = new TreeNode { Data = 3 }; 
            //root.Right.Right = new TreeNode { Data = 12 };
            //root.Right.Left = new TreeNode { Data = 7 };

            //Console.WriteLine("InCorrect Bst Inorder traversal :");
            //InOrder(root);
            //correctBST2(root);
            //Console.WriteLine();
            //Console.WriteLine("Corrected Bst Inorder traversal");
            //InOrder(root);

        }

        static void CorrectBst(TreeNode node)
        {
            TreeNode[] nodesToSwap = new TreeNode[2];
            CorrectBstUtil(node, nodesToSwap, int.MaxValue, int.MinValue);
            if (nodesToSwap[0] != null && nodesToSwap[1] != null)
            {
                var temp = nodesToSwap[0].Data;
                nodesToSwap[0].Data = nodesToSwap[1].Data;
                nodesToSwap[1].Data = temp;
            }
        }

        static void CorrectBstUtil(TreeNode node, TreeNode[] nodesToSwap, int max, int min)
        {
            if (node.Data > max || node.Data < min)
            {
                if (nodesToSwap[0] == null)
                    nodesToSwap[0] = node;
                else
                    nodesToSwap[1] = node;
            }

            if (node.Left != null)
                CorrectBstUtil(node.Left, nodesToSwap, node.Data, min);
            if (node.Right != null)
                CorrectBstUtil(node.Right, nodesToSwap, max, node.Data + 1);
        }

        static void InOrder(TreeNode node)
        {
            if (node == null)
                return;

            InOrder(node.Left);
            Console.Write(node.Data + "  ");
            InOrder(node.Right);
        }





        static TreeNode firstStartPoint, lastEndPoint, prevNode;


        static void recoverTree(TreeNode root)
        {
            InOrderTraversal(root);

            //swap(firstStartPoint.Data, lastEndPoint.Data);
            int x = firstStartPoint.Data;
            firstStartPoint.Data = lastEndPoint.Data;
            lastEndPoint.Data = x;
        }
        static void InOrderTraversal(TreeNode root)
        {
            if (root == null) return;

            InOrderTraversal(root.Left);

            if (prevNode != null && prevNode.Data > root.Data)
            {
                if (firstStartPoint == null)
                    firstStartPoint = prevNode;

                lastEndPoint = root;
            }

            prevNode = root;

            InOrderTraversal(root.Right);
        }







        // A function to fix a given BST where two nodes are swapped.  This
        // function uses correctBSTUtil() to find out two nodes and swaps the
        // nodes to fix the BST
        static void correctBST2(TreeNode root)
        {
            // Initialize pointers needed for correctBSTUtil()
            TreeNode first, middle, last, prev;
            first = middle = last = prev = null;

            // Set the poiters to find out two nodes
            correctBSTUtil2(root, first, middle, last, prev);

            // Fix (or correct) the tree
            if (first != null && last != null)
            {
                int t = first.Data;
                first.Data = last.Data;
                last.Data = t;
            }
            else if (first != null && middle != null)
            {
                int t = first.Data;
                first.Data = middle.Data;
                middle.Data = t;
            } // Adjacent nodes swapped


            // else nodes have not been swapped, passed tree is really BST.
        }

        // This function does inorder traversal to find out the two swapped nodes.
        // It sets three pointers, first, middle and last.  If the swapped nodes are
        // adjacent to each other, then first and middle contain the resultant nodes
        // Else, first and last contain the resultant nodes
        static void correctBSTUtil2(TreeNode root, TreeNode first, TreeNode middle, TreeNode last,
                     TreeNode prev)
        {
            if (root != null)
            {
                // Recur for the Left subtree
                correctBSTUtil2(root.Left, first, middle, last, prev);

                // If this node is smaller than the previous node, it's violating
                // the BST rule.
                if (prev != null && root.Data < prev.Data)
                {
                    // If this is first violation, mark these two nodes as
                    // 'first' and 'middle'
                    if (first == null)
                    {
                        first = prev;
                        middle = root;
                    }

                    // If this is second violation, mark this node as last
                    else
                        last = root;
                }

                // Mark this node as previous
                prev = root;

                // Recur for the Right subtree
                correctBSTUtil2(root.Right, first, middle, last, prev);
            }
        }

        // A utility function to swap two integers
        static void swap(int a, int b)
        {
            int t = a;
            a = b;
            b = t;
        }


        /* A binary tree node has Data, pointer to Left child
           and a pointer to Right child */
    }

    class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode (int data)
        {
            this.Data = data;
        }
    }
}

//http://www.ideserve.co.in/learn/how-to-recover-a-binary-search-tree-if-two-nodes-are-swapped


//http://code.geeksforgeeks.org/msQ6MS

//http://www.geeksforgeeks.org/fix-two-swapped-nodes-of-bst/

//Average Difficulty : 3.5/5.0
//Based on 92 vote(s)


/*
 
    Two of the nodes of a Binary Search Tree (BST) are swapped. Fix (or correct) the BST.




    The inorder traversal of a BST produces a sorted array. 
    So a simple method is to store inorder traversal of the input tree in an auxiliary array. 
    Sort the auxiliary array. Finally, insert the auxiilary array elements back to the BST, keeping the structure of the BST same. 
    Time complexity of this method is O(nLogn) and auxiliary space needed is O(n).



    -----------------------------------------------------------------------------------------------------------
    BUT, we can solve this in O(n) time and with a single traversal of the given BST
    -----------------------------------------------------------------------------------------------------------

    The main idea that we are going to use is that in-order traversal array for a BST would be a sorted array.
    If this order is not maintained, then we know that the nodes are not correctly placed.
    
    ALGO::

    We can solve this in O(n) time and with a single traversal of the given BST. 
    Since inorder traversal of BST is always a sorted array, 
    the problem can be reduced to a problem where two elements of a sorted array are swapped. 

























    1. Initialize firstStartPoint = null, lastEndPoint = null, previous_node = null
    2. Visit all nodes of a tree in in-order fashion. Keep track of previously visited node.
    3. At each node that is being visited, 
            if (previously visited node > current node)
            {
                if(firstStartPoint == null)
                {
                    firstStartPoint = previous_node
                }
                lastEndPoint = current_node;
            }
    4. After all nodes are visited :swap firstStartPoint with lastEndPoint   

 */
