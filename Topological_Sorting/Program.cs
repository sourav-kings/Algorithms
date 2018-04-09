using System;
using System.Collections.Generic;

namespace Topological_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a graph given in the above diagram
            Graph g = new Graph(6);
            g.addEdge(5, 2);
            g.addEdge(5, 0);
            g.addEdge(4, 0);
            g.addEdge(4, 1);
            g.addEdge(2, 3);
            g.addEdge(3, 1);

            Console.WriteLine("Following is a Topological " +
                               "sort of the given graph");
            g.topologicalSort();
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

        // A recursive function used by topologicalSort
        public void topologicalSortUtil(int v, bool[] visited, LinkedList<int> sortedList)
        {
            // Mark the current node as visited.
            visited[v] = true;

            // Recur for all the vertices adjacent to this vertex
            IEnumerator<int> i = adj[v].GetEnumerator();
            while (i.MoveNext())
            {
                int n = i.Current;
                if (visited[n] == false)
                    topologicalSortUtil(n, visited, sortedList);
            }

            // Push current vertex to stack which stores result
            sortedList.AddFirst(v);
        }

        // The function to do Topological Sort. It uses
        // recursive topologicalSortUtil()
        public void topologicalSort()
        {
            LinkedList<int> sortedList = new LinkedList<int>();

            // Mark all the vertices as not visited
            bool[] visited = new bool[numberOfVertex];
            for (int i = 0; i < numberOfVertex; i++)
                visited[i] = false;

            // Call the recursive helper function to store
            // Topological Sort starting from all vertices
            // one by one
            for (int i = 0; i < numberOfVertex; i++)
                if (visited[i] == false)
                    topologicalSortUtil(i, visited, sortedList);

            // Print contents of stack
            while (sortedList.Count != 0)
            {
                Console.Write(sortedList.First.Value + " ");
                sortedList.RemoveFirst();
            }
                
        }

    }
    class AdjacencyLists : Queue<int>
    {
    }
}


/*
 * Created - March 2018
 * (3.2 out of 5 - rated by 177 users)
 * References
 * https://www.geeksforgeeks.org/topological-sorting/
 * Introduction To Algorithms - CLRS
 */
