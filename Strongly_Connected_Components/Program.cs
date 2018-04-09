using System;
using System.Collections.Generic;

namespace Kosaraju_StronglyConnectedComponents
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a graph given in the above diagram
            Graph g = new Graph(5);
            g.addEdge(1, 0);
            g.addEdge(0, 2);
            g.addEdge(2, 1);
            g.addEdge(0, 3);
            g.addEdge(3, 4);

            Console.WriteLine("Following are strongly connected components " +
                               "in given graph ");
            g.printSCCs();
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

        // A function used by DFS
        public void DFSUtil(int v, bool[] visited)
        {
            // Mark the current node as visited and print it
            visited[v] = true;
            Console.Write(v + " ");

            // Recur for all the vertices adjacent to this vertex
            IEnumerator<int> i = adj[v].GetEnumerator();
            while (i.MoveNext())
            {
                int n = i.Current;
                if (visited[n] == false)
                    DFSUtil(n, visited);
            }
        }

        // Function that returns reverse (or transpose) of this graph
        public Graph getTranspose()
        {
            Graph g = new Graph(numberOfVertex);
            for (int v = 0; v < numberOfVertex; v++)
            {
                // Recur for all the vertices adjacent to this vertex
                IEnumerator<int> i = adj[v].GetEnumerator();
                while (i.MoveNext())
                    g.adj[i.Current].Enqueue(v);
            }
            return g;
        }

        public void fillOrder(int v, bool[] visited, LinkedList<int> sortedList)
        {
            // Mark the current node as visited and print it
            visited[v] = true;

            // Recur for all the vertices adjacent to this vertex
            IEnumerator<int> i = adj[v].GetEnumerator();
            while (i.MoveNext())
            {
                int n = i.Current;
                if (!visited[n])
                    fillOrder(n, visited, sortedList);
            }

            // All vertices reachable from v are processed by now,
            // push v to Stack
            sortedList.AddFirst(v);
        }

        // The main function that finds and prints all strongly connected components
        public void printSCCs()
        {
            LinkedList<int> sortedList = new LinkedList<int>();

            // Mark all the vertices as not visited (For first DFS)
            bool[] visited = new bool[numberOfVertex];
            for (int i = 0; i < numberOfVertex; i++)
                visited[i] = false;

            // Fill vertices in stack according to their finishing times
            for (int i = 0; i < numberOfVertex; i++)
                if (visited[i] == false)
                    fillOrder(i, visited, sortedList);

            // Create a reversed graph
            Graph gr = getTranspose();

            // Mark all the vertices as not visited (For second DFS)
            for (int i = 0; i < numberOfVertex; i++)
                visited[i] = false;

            // Now process all vertices in order defined by Stack
            while (sortedList.Count != 0)
            {
                // Pop a vertex from stack
                int v = sortedList.First.Value;
                sortedList.RemoveFirst();

                // Print Strongly connected component of the popped vertex
                if (visited[v] == false)
                {
                    gr.DFSUtil(v, visited);
                    Console.WriteLine();
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
 * (3.9 out of 5 - rated by 87 users)
 * 
 * Clear definition - (HackerEarth)
 * A directed graph is strongly connected if there is a directed path from any vertex to every other vertex.
 * 
 * 
 * References
 * https://www.geeksforgeeks.org/strongly-connected-components/
 * Introduction To Algorithms - CLRS
 */
