using System;

namespace Convert_BinaryTree_To_DoublyLinkedList
{
    class Program
    {
        static Node prev;
        static void Main(string[] args)
        {
            // Let us create the tree shown in above diagram
            Node root = new Node(10);
            root.left = new Node(12);
            root.right = new Node(15);
            root.left.left = new Node(25);
            root.left.right = new Node(30);
            root.right.left = new Node(36);

            Console.WriteLine("Inorder Tree Traversal");
            Inorder(root);

            Node head = BTTtoDLL(root);

            Console.WriteLine("\nDLL Traversal");
            Printlist(head);
        }

        // Standard Inorder traversal of tree
        static void Inorder(Node root)
        {
            if (root == null)
                return;
            Inorder(root.left);
            Console.Write(root.data + " ");
            Inorder(root.right);
        }

        
        static Node BTTtoDLL(Node root)
        {
            prev = null;

            // Set the previous pointer
            FixPrevptr(root);

            // Set the next pointer and return head of DLL
            return FixNextptr(root);
        }


        // Changes left pointers to work as previous 
        // pointers in converted DLL The function 
        // simply does inorder traversal of Binary 
        // Tree and updates left pointer using 
        // previously visited node
        static void FixPrevptr(Node root)
        {
            if (root == null)
                return;

            FixPrevptr(root.left);
            root.left = prev;
            prev = root;
            FixPrevptr(root.right);

        }

        // Changes right pointers to work 
        // as next pointers in converted DLL
        static Node FixNextptr(Node root)
        {
            // Find the right most node in 
            // BT or last node in DLL
            while (root.right != null)
                root = root.right;

            // Start from the rightmost node, traverse 
            // back using left pointers. While traversing, 
            // change right pointer of nodes
            while (root != null && root.left != null)
            {
                Node left = root.left;
                left.right = root;
                root = root.left;
            }

            // The leftmost node is head of linked list, return it
            return root;
        }


        // Traverses the DLL from left tor right
        static void Printlist(Node root)
        {
            while (root != null)
            {
                Console.Write(root.data + " ");
                root = root.right;
            }
        }


    }

    class Node
    {
        public int data;
        public Node left, right;

        public Node(int data)
        {
            this.data = data;
        }
    }


}


//https://www.geeksforgeeks.org/convert-a-given-binary-tree-to-doubly-linked-list-set-2/