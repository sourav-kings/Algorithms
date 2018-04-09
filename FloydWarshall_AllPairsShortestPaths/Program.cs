﻿using System;

namespace FloydWarshall_AllPairsShortestPaths
{
    class Program
    {
        private const int INF = 99999, V = 4;
        static void Main(string[] args)
        {
            /* Let us create the following weighted graph
                       10
                    (0)------->(3)
                    |         /|\
                    5 |          |
                    |          | 1
                    \|/         |
                    (1)------->(2)
                          3           
            */
            int[,] graph = { {0,   5,  INF, 10},
                          {INF, 0,   3, INF},
                          {INF, INF, 0,   1},
                          {INF, INF, INF, 0}
                        };

            // Print the solution
            FloydWarshall(graph);
        }

        static void FloydWarshall(int[,] graph)
        {
            int[,] dist = new int[V, V];
            int i, j, k;

            /* Initialize the solution matrix same as input graph matrix.
               Or we can say the initial values of shortest distances
               are based on shortest paths considering no intermediate
               vertex. */
            for (i = 0; i < V; i++)
                for (j = 0; j < V; j++)
                    dist[i, j] = graph[i, j];

            /* Add all vertices one by one to the set of intermediate
               vertices.
              ---> Before start of a iteration, we have shortest
                   distances between all pairs of vertices such that
                   the shortest distances consider only the vertices in
                   set {0, 1, 2, .. k-1} as intermediate vertices.
              ----> After the end of a iteration, vertex no. k is added
                    to the set of intermediate vertices and the set
                    becomes {0, 1, 2, .. k} */
            for (k = 0; k < V; k++)
            {
                // Pick all vertices as source one by one
                for (i = 0; i < V; i++)
                {
                    // Pick all vertices as destination for the
                    // above picked source
                    for (j = 0; j < V; j++)
                    {
                        // If vertex k is on the shortest path from
                        // i to j, then update the value of dist[i][j]
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                            dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }

            // Print the shortest distance matrix
            PrintSolution(dist);
        }

        static void PrintSolution(int[,] dist)
        {
            Console.WriteLine("Following matrix shows the shortest " +
                             "distances between every pair of vertices");
            for (int i = 0; i < V; ++i)
            {
                for (int j = 0; j < V; ++j)
                {
                    if (dist[i,j] == INF)
                        Console.Write("INF ");
                    else
                        Console.Write(dist[i,j] + "   ");
                }
                Console.WriteLine();
            }
        }
    }
}

/*
 * https://www.geeksforgeeks.org/dynamic-programming-set-16-floyd-warshall-algorithm/
 * 
 * Time Complexity: O(V^3)
 * 
 * 2.7 (145)
 
     */
