using System;

namespace ExtractLeaves_Of_BinaryTree_DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);

            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);
            tree.root.right.right = new Node(6);
            tree.root.left.left.left = new Node(7);
            tree.root.left.left.right = new Node(8);
            tree.root.right.right.left = new Node(9);
            tree.root.right.right.right = new Node(10);

            Console.WriteLine("Inorder traversal of given tree is : ");
            tree.Inorder(tree.root);
            tree.ExtractLeafList(tree.root);
            Console.WriteLine("");
            Console.WriteLine("Extracted double link list is : ");
            tree.PrintDLL(tree.head);
            Console.WriteLine("");
            Console.WriteLine("Inorder traversal of modified tree is : ");
            tree.Inorder(tree.root);
        }
    }


    public class BinaryTree
    {
        internal Node root;
        internal Node head; // will point to head of DLL  
        internal Node prev; // temporary pointer 

        // The main fuction that links the list list to be traversed
        internal Node ExtractLeafList(Node root)
        {
            if (root == null)
                return null;

            if (root.left == null && root.right == null)
            {
                if (head == null)
                {
                    head = root;
                    prev = root;
                }
                else
                {
                    prev.right = root;
                    root.left = prev;
                    prev = root;
                }
                return null;
            }
            root.left = ExtractLeafList(root.left);
            root.right = ExtractLeafList(root.right);
            return root;
        }

        //Prints the DLL in both forward and reverse directions.
        internal void PrintDLL(Node head)
        {
            Node last = null;
            while (head != null)
            {
                Console.WriteLine(head.data + " ");
                last = head;
                head = head.right;
            }
        }

        internal void Inorder(Node node)
        {
            if (node == null)
                return;
            Inorder(node.left);
            Console.WriteLine(node.data + " ");
            Inorder(node.right);
        }
    }

    // A binay tree node
    class Node
    {
        internal int data;
        internal Node left, right;

        internal Node(int item)
        {
            data = item;
            right = left = null;
        }
    }
}
/*
 * https://www.geeksforgeeks.org/connect-leaves-doubly-linked-list/
 */
