using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_If_BinaryTree_Subtree_Of_Another_BinaryTree
{
    class Program
    {
        static Node root1, root2;
        static Passing p = new Passing();
        static void Main(string[] args)
        {
            // TREE 1
            /* Construct the following tree
                  26
                 /   \
                10     3
               /    \     \
              4      6      3
               \
                30  */

            root1 = new Node(26);
            root1.right = new Node(3);
            root1.right.right = new Node(3);
            root1.left = new Node(10);
            root1.left.left = new Node(4);
            root1.left.left.right = new Node(30);
            root1.left.right = new Node(6);

            // TREE 2
            /* Construct the following tree
               10
             /    \ 
             4      6
              \
              30  */

            root2 = new Node(10);
            root2.left = new Node(4);
            root2.left.right = new Node(30);
            root2.right = new Node(6);

            if (isSubtree(root1, root2))
                Console.WriteLine("Tree 2 is subtree of Tree 1 ");
            else
                Console.WriteLine("Tree 2 is not a subtree of Tree 1");

            //if (isSubtreeFaster(root1, root2))
            //    Console.WriteLine("Tree 2 is subtree of Tree 1 ");
            //else
            //    Console.WriteLine("Tree 2 is not a subtree of Tree 1");

            if (checkIfSubtree(root1, root2))
                Console.WriteLine("Tree 2 is subtree of Tree 1 ");
            else
                Console.WriteLine("Tree 2 is not a subtree of Tree 1");


            Console.WriteLine("\n");

            Node rootA = new Node(1);
            rootA.left = new Node(2);
            rootA.right = new Node(4);
            rootA.left.left = new Node(3);
            rootA.right.right = new Node(6);
            rootA.right.left = new Node(5);

            Node rootB = new Node(4);
            rootB.left = new Node(5);
            rootB.right = new Node(6);


            if (isSubtree(rootA, rootB))
                Console.WriteLine("Tree B is subtree of Tree A ");
            else
                Console.WriteLine("Tree B is not a subtree of Tree A ");

            //if (isSubtreeFaster(rootA, rootB))
            //    Console.WriteLine("Tree B is subtree of Tree A ");
            //else
            //    Console.WriteLine("Tree B is not a subtree of Tree A ");

            if (checkIfSubtree(rootA, rootB))
                Console.WriteLine("Tree B is subtree of Tree A ");
            else
                Console.WriteLine("Tree B is not a subtree of Tree A "); 
        }

        /* A utility function to check whether trees with roots as root1 and
        root2 are identical or not */
        static bool areIdentical(Node root1, Node root2)
        {

            /* base cases */

            //if both trees are null, then they're identitical
            if (root1 == null && root2 == null)
                return true;

            //if both trees are NOT identical but either of them is, then they're NOT identitical.
            if (root1 == null || root2 == null)
                return false;

            /* Check if the data of both roots is same and data of left and right
               subtrees are also same */
            return (root1.data == root2.data
                    && areIdentical(root1.left, root2.left)
                    && areIdentical(root1.right, root2.right));
        }

        /* This function returns true if S is a subtree of T, otherwise false */
        static bool isSubtree(Node T, Node S)
        {
            /* base cases */
            //if the 2nd tree is null, then 2nd tree IS a subtree of 1st tree.
            if (S == null)
                return true;

            //if 2nd tree is NOT null but 1st tree is, then 2nd tree is NOT a subtree of 1st tree.
            if (T == null)
                return false;

            /* Check the tree with root as current node */
            if (areIdentical(T, S))
                return true;

            /* If the tree with root as current node doesn't match then
               try left and right subtrees one by one */
            return isSubtree(T.left, S)
                    || isSubtree(T.right, S);
        }








        static string strstr(string haystack, string needle)
        {
            if (haystack == null || needle == null)
            {
                return null;
            }
            int hLength = haystack.Length;
            int nLength = needle.Length;
            if (hLength < nLength)
            {
                return null;
            }
            if (nLength == 0)
            {
                return haystack;
            }
            for (int i = 0; i <= hLength - nLength; i++)
            {
                if (haystack[i] == needle[0])
                {
                    int j = 0;
                    for (; j < nLength; j++)
                    {
                        if (haystack[i + j] != needle[j])
                        {
                            break;
                        }
                    }
                    if (j == nLength)
                    {
                        return haystack.Substring(i);
                    }
                }
            }
            return null;
        }

        // A utility function to store inorder traversal of tree rooted
        // with root in an array arr[]. Note that i is passed as reference
        static void storeInorder(Node node, char[] arr, Passing i)
        {
            if (node == null)
            {
                arr[i.i++] = '$';
                return;
            }
            storeInorder(node.left, arr, i);
            arr[i.i++] = Convert.ToChar(node.data);
            storeInorder(node.right, arr, i);
        }

        // A utility function to store preorder traversal of tree rooted
        // with root in an array arr[]. Note that i is passed as reference
        static void storePreOrder(Node node, char[] arr, Passing i)
        {
            if (node == null)
            {
                arr[i.i++] = '$';
                return;
            }
            arr[i.i++] = Convert.ToChar(node.data);
            storePreOrder(node.left, arr, i);
            storePreOrder(node.right, arr, i);
        }

        /* This function returns true if S is a subtree of T, otherwise false */
        static bool isSubtreeFaster(Node T, Node S)
        {
            /* base cases */
            if (S == null)
            {
                return true;
            }
            if (T == null)
            {
                return false;
            }

            // Store Inorder traversals of T and S in inT[0..m-1]
            // and inS[0..n-1] respectively
            char[] inT = new char[100];
            string op1 = new string(inT);
            char[] inS = new char[100];
            string op2 = new string(inS);
            storeInorder(T, inT, p);
            storeInorder(S, inS, p);
            inT[p.m] = '\0';
            inS[p.m] = '\0';

            // If inS[] is not a substring of preS[], return false
            if (strstr(op1, op2) != null)
            {
                return false;
            }

            // Store Preorder traversals of T and S in inT[0..m-1]
            // and inS[0..n-1] respectively
            p.m = 0;
            p.n = 0;
            char[] preT = new char[100];
            char[] preS = new char[100];
            string op3 = new string(preT);
            string op4 = new string(preS);
            storePreOrder(T, preT, p);
            storePreOrder(S, preS, p);
            preT[p.m] = '\0';
            preS[p.n] = '\0';

            // If inS[] is not a substring of preS[], return false
            // Else return true
            return (strstr(op3, op4) != null);
        }







        static private void fillUpPreorderString(String[] traversalString, Node node)
        {
            if (node == null)
                return;

            traversalString[0] += node.data;
            fillUpPreorderString(traversalString, node.left);
            fillUpPreorderString(traversalString, node.right);
        }


        static private void fillUpInorderString(String[] traversalString, Node node)
        {
            if (node == null)
                return;

            fillUpInorderString(traversalString, node.left);
            traversalString[0] += node.data;
            fillUpInorderString(traversalString, node.right);
        }


        static public bool checkIfSubtree(Node bigTree, Node smallTree)
        {
            string[] inorderForBigTree = { "" };
            string[] inorderForSmallTree = { "" };

            fillUpInorderString(inorderForBigTree, bigTree);
            fillUpInorderString(inorderForSmallTree, smallTree);

            if (inorderForBigTree[0].Contains(inorderForSmallTree[0]))
            {
                string[] preorderForBigTree = { "" };
                string[] preorderForSmallTree = { "" };

                fillUpPreorderString(preorderForBigTree, bigTree);
                fillUpPreorderString(preorderForSmallTree, smallTree);

                return preorderForBigTree[0].Contains(preorderForSmallTree[0]);
            }

            return false;
        }
    }

    // A binary tree node
    class Node
    {
        public int data;
        public Node left, right, nextRight;

        public Node(int item)
        {
            data = item;
            left = right = nextRight = null;
        }
    }

    class Passing
    {

        public int i;
        public int m = 0;
        public int n = 0;
    }
}


/*
 * OBJECTIVE :-
 *      check if the first tree is subtree of the second one.
 */

//a O(n*n) solution for this problem. 
//Time Complexity: Time worst case complexity of this solution is O(m*n) where m and n are number of nodes in given two trees.
//Solution: Traverse the tree T in preorder fashion. For every visited node in the traversal, 
//see if the subtree rooted with this node is identical to S.
//http://www.geeksforgeeks.org/check-if-a-binary-tree-is-subtree-of-another-binary-tree/


//a O(n) solution is discussed.
//http://www.geeksforgeeks.org/check-binary-tree-subtree-another-binary-tree-set-2/

/*
 * The idea is based on the fact that inorder and preorder/postorder uniquely identify a binary tree. 
 * Tree S is a subtree of T if both inorder and preorder traversals of S arew substrings of inorder and preorder traversals of T respectively.

    Following are detailed steps.

    1) Find inorder and preorder traversals of T, store them in two auxiliary arrays inT[] and preT[].

    2) Find inorder and preorder traversals of S, store them in two auxiliary arrays inS[] and preS[].

    3) If inS[] is a subarray of inT[] and preS[] is a subarray preT[], then S is a subtree of T. Else not.

    We can also use postorder traversal in place of preorder in the above algorithm.

    Let us consider the above example

    Inorder and Preorder traversals of the big tree are.
    inT[]   =  {a, c, x, b, z, e, k}
    preT[]  =  {z, x, a, c, b, e, k}

    Inorder and Preorder traversals of small tree are
    inS[]  = {a, c, x, b}
    preS[] = {x, a, c, b}

    We can easily figure out that inS[] is a subarray of
    inT[] and preS[] is a subarray of preT[]. 
    EDIT

    The above algorithm doesn't work for cases where a tree is present
    in another tree, but not as a subtree. Consider the following example.

        Tree1
          x 
        /    \
      a       b
     /        
    c         


        Tree2
          x 
        /    \
      a       b
     /         \
    c            d

    Inorder and Preorder traversals of the big tree or Tree2 are.

    Inorder and Preorder traversals of small tree or Tree1 are

    The Tree2 is not a subtree of Tree1, but inS[] and preS[] are
    subarrays of inT[] and preT[] respectively.
    The above algorithm can be extended to handle such cases by adding a special character whenever we encounter NULL in inorder and preorder traversals.
 */





















/*
O(n * n) Solution
Average Difficulty : 2.5/5.0
Based on 89 vote(s)


O(n) Solution
Average Difficulty : 3.5/5.0
Based on 72 vote(s) 

 */




/*
 * ALGO::
 * 
 * 0. 
 * 1. Call function with two tree nodes.
 * 2. Create two new string arrays and store element  inorder traveral of both nodes as the first element.
 * 3. If first element of bigger one is same as that of smaller one::
 *      Create two new string arrays and store preorder traveral of both nodes as the first element.
 *      If first element of bigger one is same as  that of small one, return true.
 * 6. Return false in the last line, for the case if nothing matched up.
 */
