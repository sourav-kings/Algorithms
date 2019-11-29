using System;

namespace Extract_Leaves_Of_BinaryTree_In_DoublyLinkedList
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
                Console.Write(head.data + " ");
                last = head;
                head = head.right;
            }
        }

        internal void Inorder(Node node)
        {
            if (node == null)
                return;
            Inorder(node.left);
            Console.Write(node.data + " ");
            Inorder(node.right);
        }
    }


    // A binay tree node
    public class Node
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
 * Extract Leaves of a Binary Tree in a Doubly Linked List
 * 
 * https://www.geeksforgeeks.org/connect-leaves-doubly-linked-list/
 * 
 * 
 * ALGO::
 * 
 * We need to traverse all leaves and connect them by changing their left and right pointers. 
 * We also need to remove them from Binary Tree by changing left or right pointers in parent nodes. 
 * There can be many ways to solve this.
 * In the following implementation, we add leaves at the beginning of current linked list 
 * and update head of the list using pointer to head pointer. 
 * Since we insert at the beginning, we need to process leaves in reverse order. 
 * For reverse order, we first traverse the right subtree then the left subtree. 
 * We use return values to update left or right pointers in parent nodes.
 */
