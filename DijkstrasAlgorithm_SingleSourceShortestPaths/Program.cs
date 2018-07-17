using System;

namespace DijkstrasAlgorithm_SingleSourceShortestPaths
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Let us create the example graph discussed above */
            int[,] graph = new int[,]{
                {0, 4, 0, 0, 0, 0, 0, 8, 0},
                {4, 0, 8, 0, 0, 0, 0, 11, 0},
                {0, 8, 0, 7, 0, 4, 0, 0, 2},
                {0, 0, 7, 0, 9, 14, 0, 0, 0},
                {0, 0, 0, 9, 0, 10, 0, 0, 0},
                {0, 0, 4, 14, 10, 0, 2, 0, 0},
                {0, 0, 0, 0, 0, 2, 0, 1, 6},
                {8, 11, 0, 0, 0, 0, 1, 0, 7},
                {0, 0, 2, 0, 0, 0, 6, 7, 0}
            };
            ShortestPath t = new ShortestPath();
            t.Dijkstra(graph, 0);
        }
    }

    class ShortestPath
    {
        // A utility function to find the vertex with minimum distance value,
        // from the set of vertices not yet included in shortest path tree
        const int V = 9;
        int MinDistance(int[] dist, Boolean[] sptSet)
        {
            // Initialize min value
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        // A utility function to print the constructed distance array
        void PrintSolution(int[] dist, int n)
        {
            Console.WriteLine("Vertex   Distance from Source");
            for (int i = 0; i < V; i++)
                Console.WriteLine(i + " \t\t " + dist[i]);
        }

        // Funtion that implements Dijkstra's single source shortest path
        // algorithm for a graph represented using adjacency matrix
        // representation
        public void Dijkstra(int[,] graph, int src)
        {
            int[] dist = new int[V]; // The output array. dist[i] will hold
                                     // the shortest distance from src to i

            // sptSet[i] will true if vertex i is included in shortest
            // path tree or shortest distance from src to i is finalized
            Boolean[] sptSet = new Boolean[V];

            // Initialize all distances as INFINITE and stpSet[] as false
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // Distance of source vertex from itself is always 0
            dist[src] = 0;

            // Find shortest path for all vertices
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum distance vertex from the set of vertices
                // not yet processed. u is always equal to src in first
                // iteration.
                int u = MinDistance(dist, sptSet);

                // Mark the picked vertex as processed
                sptSet[u] = true;

                // Update dist value of the adjacent vertices of the
                // picked vertex.
                for (int v = 0; v < V; v++)

                    // Update dist[v] only if is not in sptSet, there is an
                    // edge from u to v, and total weight of path from src to
                    // v through u is smaller than current value of dist[v]
                    if (!sptSet[v] && graph[u, v] != 0 &&
                            dist[u] != int.MaxValue &&
                            dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }

            // print the constructed distance array
            PrintSolution(dist, V);
        }
    }
}


/*
 https://www.geeksforgeeks.org/greedy-algorithms-set-6-dijkstras-shortest-path-algorithm/

    (3.1 / 138)

    OBJECTIVE:-

    Dijkstra’s algorithm to find the shortest path 
    from a single source vertex to all other vertices in the given graph.

    1. generate a SPT (shortest path tree) with given source as root.

    2. maintain two sets, 
        A --> one set contains vertices included in shortest path tree, 
        B --> other set includes vertices not yet included in shortest path tree.  
    
    3. At every step of the algorithm, 
        we find a vertex which is in the other set (set of not yet included) and 
        has a minimum distance from the source.



    ** Put all vertices in Set B.
    ** Assign root vertex as Zero, and all others as Infinite.
    ** Keep iteratin over Set B, until Set A has all vertices. 
        **  For current vertex, update Distances for all adjacent vertices.
        **  For each adjacent vertex V, update the distance.
        **   By default distance is V. But if [D(u) + D(u,v)] < [D(v)], 
               distance updates to [D(u) + D(u,v)].
        **  
*/
