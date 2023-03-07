using System;
using System.Collections.Generic;

namespace TrabalhoFinalCPA
{
    public class MazeSolver
    {
        private static int[,] directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

        public static List<Tuple<int, int>> SolveMaze(int[][] maze)
        {
            int rows = maze.Length;
            int cols = maze[0].Length;
            bool[,] visited = new bool[rows, cols];

            List<Tuple<int, int>> path = new List<Tuple<int, int>>();
            Tuple<int, int> start = new Tuple<int, int>(0, 0);
            Tuple<int, int> end = new Tuple<int, int>(rows - 1, cols - 1);

            bool found = SolveMazeUtil(maze, start, end, visited, path);

            if (found)
            {
                path.Insert(0, start);
            }
            return path;
        }

        private static bool SolveMazeUtil(int[][] maze, Tuple<int, int> current, Tuple<int, int> end, bool[,] visited, List<Tuple<int, int>> path)
        {
            if (current.Equals(end))
            {
                return true;
            }

            visited[current.Item1, current.Item2] = true;

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int newRow = current.Item1 + directions[i, 0];
                int newCol = current.Item2 + directions[i, 1];

                if (newRow >= 0 && newRow < maze.Length && newCol >= 0 && newCol < maze[0].Length && !visited[newRow, newCol] && maze[newRow][newCol] == 0)
                {
                    Tuple<int, int> next = new Tuple<int, int>(newRow, newCol);

                    if (SolveMazeUtil(maze, next, end, visited, path))
                    {
                        path.Insert(0, next);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
