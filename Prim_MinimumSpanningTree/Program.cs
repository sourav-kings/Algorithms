using System;

namespace Prim_MinimumSpanningTree
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Let us create the following graph
                   2    3
               (0)---(1)---(2)
                |    / \    |
               6|  8/   \5  |7
                |  /      \ |
               (3)---------(4)
                     9          
            */

            int[,] graph = new int[,] {{0, 2, 0, 6, 0},
                                    {2, 0, 3, 8, 5},
                                    {0, 3, 0, 0, 7},
                                    {6, 8, 0, 0, 9},
                                    {0, 5, 7, 9, 0},
                                    };

            // Print the solution
            PrimMST(graph);
        }

        // Number of vertices in the graph
        static private int V = 5;

        // A utility function to print the constructed MST stored in
        // parent[]
        static void PrintMST(int[] parent, int n, int[,] graph)
        {
            Console.WriteLine("Edge   Weight");
            for (int i = 1; i < V; i++)
                Console.WriteLine(parent[i] + " - " + i + "    " +
                                   graph[i, parent[i]]);
        }

        // Function to construct and print MST for a graph represented
        //  using adjacency matrix representation
        static void PrimMST(int[,] graph)
        {
            // Array to store constructed MST
            int[] parent = new int[V];

            // Key values used to pick minimum weight edge in cut
            int[] key = new int[V];

            // To represent set of vertices not yet included in MST
            Boolean[] mstSet = new Boolean[V];

            // Initialize all keys as INFINITE
            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            // Always include first 1st vertex in MST.
            key[0] = 0;     // Make key 0 so that this vertex is
                            // picked as first vertex
            parent[0] = -1; // First node is always root of MST

            // The MST will have V vertices
            for (int count = 0; count < V - 1; count++)
            {
                // Pick thd minimum key vertex from the set of vertices
                // not yet included in MST
                int u = MinKey(key, mstSet);

                // Add the picked vertex to the MST Set
                mstSet[u] = true;

                // Update key value and parent index of the adjacent
                // vertices of the picked vertex. Consider only those
                // vertices which are not yet included in MST
                for (int v = 0; v < V; v++)

                    // graph[u][v] is non zero only for adjacent vertices of m
                    // mstSet[v] is false for vertices not yet included in MST
                    // Update the key only if graph[u][v] is smaller than key[v]
                    if (graph[u, v] != 0 && mstSet[v] == false &&
                        graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
            }

            // print the constructed MST
            PrintMST(parent, V, graph);
        }

        // A utility function to find the vertex with minimum key
        // value, from the set of vertices not yet included in MST
        static int MinKey(int[] key, Boolean[] mstSet)
        {
            // Initialize min value
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    min_index = v;
                }

            return min_index;
        }

    }
}


/*
 * 
 * (3.1 / 111)
 * 
 * Time Complexity of the above program is O(V^2). 
 * If the input graph is represented using adjacency list, then the 
 * time complexity of Prim’s algorithm can be reduced to O(E log V) 
 * with the help of binary heap. Please see Prim’s MST for 
 * Adjacency List Representation for more details.
 */
