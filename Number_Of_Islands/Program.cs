using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Of_Islands
{
    class Program
    {
        //No of rows and columns
        static int ROW = 5, COL = 5;

        static void Main(string[] args)
        {
            int[,] M =  new int[,] {
                {1, 1, 0, 0, 0},
                {0, 1, 0, 0, 1},
                {1, 0, 0, 1, 1},
                {0, 0, 0, 0, 0},
                {1, 0, 1, 0, 1}
            };
            Console.WriteLine("Number of islands is: "+ countIslands(M));
        }

        // A function to check if a given cell (row, col) can
        // be included in DFS
        static bool isSafe(int[,] M, int row, int col, bool[,] visited)
        {
            // row number is in range, column number is in range
            // and value is 1 and not yet visited
            return (row >= 0) && (row < ROW) &&
                   (col >= 0) && (col < COL) &&
                   (M[row,col] == 1 && !visited[row,col]);
        }

        // A utility function to do DFS for a 2D boolean matrix.
        // It only considers the 8 neighbors as adjacent vertices
        static void DFS(int[,] M, int row, int col, bool[,] visited)
        {
            // These arrays are used to get row and column numbers
            // of 8 neighbors of a given cell
            int[] rowNbr = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colNbr = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

            // Mark this cell as visited
            visited[row,col] = true;

            // Recur for all connected neighbours
            for (int k = 0; k < 8; ++k)
                if (isSafe(M, row + rowNbr[k], col + colNbr[k], visited))
                    DFS(M, row + rowNbr[k], col + colNbr[k], visited);
        }

        // The main function that returns count of islands in a given
        //  boolean 2D matrix
        static int countIslands(int[,] M)
        {
            // Make a bool array to mark visited cells.
            // Initially all cells are unvisited
            bool[,] visited = new bool[ROW,COL];
 
 
            // Initialize count as 0 and travese through the all cells
            // of given matrix
            int count = 0;
            for (int i = 0; i<ROW; ++i)
                for (int j = 0; j<COL; ++j)
                    if (M[i,j]==1 && !visited[i,j]) // If a cell with
                    {                                 // value 1 is not
                        // visited yet, then new island found, Visit all
                        // cells in this island and increment island count
                        DFS(M, i, j, visited);
                        ++count;
                    }
 
            return count;
        }
    }
}


//http://www.geeksforgeeks.org/find-number-of-islands/
//Average Difficulty : 3.2/5.0
//Based on 85 vote(s)


/*
 Given a boolean 2D matrix, find the number of islands. 
 A group of connected 1s forms an island. For example, the below matrix contains 5 islands


    an variation of the standard problem: “Counting number of connected components in a undirected graph”.

    what is a connected component. ????
    A connected component of an undirected graph is a subgraph in which every two vertices are connected to each other by a path(s), 
    and which is connected to no other vertices outside the subgraph.

    A graph where all vertices are connected with each other, has exactly one connected component, consisting of the whole graph. 
    Such graph with only one connected component is called as Strongly Connected Graph.

    The problem can be easily solved by applying DFS() on each component. 
    In each DFS() call, a component or a sub-graph is visited. We will call DFS on the next un-visited component. 
    The number of calls to DFS() gives the number of connected components. BFS can also be used.



    What is an island?
    A group of connected 1s forms an island. For example, the below matrix contains 5 islands

	                    {1, 1, 0, 0, 0},
                        {0, 1, 0, 0, 1},
                        {1, 0, 0, 1, 1},
                        {0, 0, 0, 0, 0},
                        {1, 0, 1, 0, 1}

     */
