using System;

namespace Construct_BinaryTree_From_ParentArrayRepresentation
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            int[] parent = new int[] { -1, 0, 0, 1, 1, 3, 5 };
            int n = parent.Length;
            Node node = CreateTree(parent, n);
            Console.WriteLine("Inorder traversal of constructed tree ");
            Inorder(node);
            Console.WriteLine("");
        }

        /* Creates tree from parent[0..n-1] and returns root of 
   the created tree */
        static Node CreateTree(int[] parent, int n)
        {
            // Create an array created[] to keep track
            // of created nodes, initialize all entries
            // as NULL
            Node[] created = new Node[n];
            for (int i = 0; i < n; i++)
                created[i] = null;

            for (int i = 0; i < n; i++)
                CreateNode(parent, i, created);

            return root;
        }

        // Creates a node with key as 'i'.  If i is root, then it changes
        // root.  If parent of i is not created, then it creates parent first
        static void CreateNode(int[] parent, int i, Node[] created)
        {
            // If this node is already created
            if (created[i] != null)
                return;

            // Create a new node and set created[i]
            created[i] = new Node(i);

            // If 'i' is root, change root pointer and return
            if (parent[i] == -1)
            {
                root = created[i];
                return;
            }

            // If parent is not created, then create parent first
            if (created[parent[i]] == null)
                CreateNode(parent, parent[i], created);

            // Find parent pointer
            Node p = created[parent[i]];

            // If this is first child of parent
            if (p.left == null)
                p.left = created[i];
            else // If second child

                p.right = created[i];
        }

        static void Inorder(Node node)
        {
            if (node != null)
            {
                Inorder(node.left);
                Console.WriteLine(node.data + " ");
                Inorder(node.right);
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

/*
 * https://www.geeksforgeeks.org/construct-a-binary-tree-from-parent-array-representation/
 */
