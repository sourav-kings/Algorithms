using System;
using System.Collections.Generic;

namespace Breadth_First_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(4);

            g.addEdge(0, 1);
            g.addEdge(0, 2);
            g.addEdge(1, 2);
            g.addEdge(2, 0);
            g.addEdge(2, 3);
            g.addEdge(3, 3);

            Console.WriteLine("Following is Breadth First Traversal " +
                               "(starting from vertex 2)");

            g.BFS(2);
        }
    }

    class Graph
    {
        int numberOfVertex;
        AdjacencyLists[] adj;

        public Graph(int n)
        {
            this.numberOfVertex = n;
            this.adj = new AdjacencyLists[numberOfVertex];

            for (int i = 0; i < numberOfVertex; i++)
                adj[i] = new AdjacencyLists();
        }

        public void addEdge(int u, int v)
        {
            adj[u].Enqueue(v);
        }

        // prints BFS traversal from a given source s
        public void BFS(int s)
        {
            // Mark all the vertices as not visited(By default
            // set as false)
            bool[] visited = new bool[numberOfVertex];

            // Create a queue for BFS
            Queue<int> queue = new Queue<int>();

            // Mark the current node as visited and enqueue it
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                // Dequeue a vertex from queue and print it
                s = queue.Dequeue();
                Console.Write(s + " ");

                // Get all adjacent vertices of the dequeued vertex s
                // If a adjacent vertex has not been visited, then mark it
                // visited and enqueue it
                IEnumerator<int> i = adj[s].GetEnumerator();
                while (i.MoveNext())
                {
                    int n = i.Current;
                    if (!visited[n])
                    {
                        visited[n] = true;
                        queue.Enqueue(n);
                    }
                }
            }
        }

    }

    class AdjacencyLists : Queue<int>
    {
    }


}


/*
 * Created - March 2018
 * (2.3 out of 5 - rated by 237 users)
 * References
 * https://www.geeksforgeeks.org/breadth-first-search-or-bfs-for-a-graph/
 * Introduction To Algorithms - CLRS
 * 
 */
