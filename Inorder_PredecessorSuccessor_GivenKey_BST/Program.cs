using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inorder_PredecessorSuccessor_GivenKey_BST
{
    class Program
    {
        public static Node root;
        public static Node pre;
        public static Node suc;
        static void Main(string[] args)
        {
            int key = 20;
            insert(70);
            insert(20);
            insert(50);
            insert(10);
            insert(30);
            insert(60);
            insert(40);

            printTree(root);
            PredSucc(root, key);
            Console.WriteLine("");
            Console.WriteLine("predecessor : " + pre.data);
            Console.WriteLine("sucsessor : " + suc.data);
        }

        static public void insert(int key)
        {
            root = insert(root, key);
        }

        static public Node insert(Node node, int key)
        {
            if (node == null)
            {
                node = new Node(key);
                return node;
            }

            if (key < node.data)
                node.left = insert(node.left, key);
            else if (key > node.data)
                node.right = insert(node.right, key);
            return node;
        }

        static public void printTree(Node node)
        {
            if (node != null)
            {
                printTree(node.left);
                Console.Write(node.data + " ");
                printTree(node.right);
            }
        }

        static public void PredSucc(Node node, int key)
        {
            if (node == null)
                return;

            if (node.data == key)
            {
                if (node.left != null)
                {
                    Node temp = node.left;
                    while (temp.right != null)
                        temp = temp.right;
                    pre = temp;
                }

                if (node.right != null)
                {
                    Node temp = node.right;
                    while (temp.left != null)
                        temp = temp.left;
                    suc = temp;
                }
            }

            if (key < node.data)
            {
                suc = node;
                PredSucc(node.left, key);
            }
            else if (key > node.data)
            {
                pre = node;
                PredSucc(node.right, key);
            }
        }


        static void predSucc_2(Node root, int a, Node p, Node q)
        {
            // If root is null return 
            if (root == null)
                return;

            // traverse the left subtree    
            predSucc_2(root.left, a, p, q);

            // root data is greater than a
            if (root != null && root.data > a)
            {

                // q stores the node whose data is greater
                // than a and is smaller than the previously
                // stored data in *q which is sucessor
                if ((q == null) || ((q != null) && (q.data > root.data)))
                    q = root;
            }

            // if the root data is smaller than
            // store it in p which is predecessor
            else if (root != null && root.data < a)
            {
                p = root;
            }

            // traverse the right subtree
            predSucc_2(root.right, a, p, q);
        }


    }

    // BST Node
    class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }
}


//http://www.geeksforgeeks.org/inorder-predecessor-successor-given-key-bst/
//Average Difficulty : 2.8/5.0
//Based on 103 vote(s)




/*

 Input: root node, key
output: predecessor node, successor node

1. If root is NULL
  then return
2. if key is found then
a. If its left subtree is not null
    Then predecessor will be the right most 
    child of left subtree or left child itself.
b. If its right subtree is not null
    The successor will be the left most child 
    of right subtree or right child itself.
return
3. If key is smaller then root node
    set the successor as root
    search recursively into left subtree
else
    set the predecessor as root
    search recursively into right subtree

 */
