using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabalhoFinalCPA
{
    public class NQueenSolver
    {
        public int[,] Solve(int n)
        {
            var board = new int[n, n];
            SolveHelper(n, 0, board);
            return board;
        }

        private bool SolveHelper(int n, int row, int[,] board)
        {
            if (row == n)
                return true;

            for (int col = 0; col < n; col++)
            {
                if (IsSafe(row, col, board))
                {
                    board[row, col] = 1;

                    if (SolveHelper(n, row + 1, board))
                        return true;

                    board[row, col] = 0;
                }
            }

            return false;
        }

        private bool IsSafe(int row, int col, int[,] board)
        {
            for (int i = 0; i < row; i++)
            {
                if (board[i, col] == 1)
                    return false;
            }

            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }

            for (int i = row, j = col; i >= 0 && j < board.GetLength(1); i--, j++)
            {
                if (board[i, j] == 1)
                    return false;
            }

            return true;
        }
    }
}
