using System;

namespace TrabalhoFinalCPA
{
    public class SudokuSolver
    {
        public int[,] Solve(int[,] board)
        {
            SolveHelper(board, 0, 0);
            return board;
        }

        private bool SolveHelper(int[,] board, int row, int col)
        {
            if (col == board.GetLength(1))
            {
                col = 0;
                row++;

                if (row == board.GetLength(0))
                    return true;
            }

            if (board[row, col] != 0)
                return SolveHelper(board, row, col + 1);

            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(num, row, col, board))
                {
                    board[row, col] = num;

                    if (SolveHelper(board, row, col + 1))
                        return true;

                    board[row, col] = 0;
                }
            }

            return false;
        }

        private bool IsSafe(int num, int row, int col, int[,] board)
        {
            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (board[row, i] == num)
                    return false;
            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, col] == num)
                    return false;
            }

            int sqrt = (int)Math.Sqrt(board.GetLength(0));
            int boxRowStart = row - row % sqrt;
            int boxColStart = col - col % sqrt;

            for (int i = boxRowStart; i < boxRowStart + sqrt; i++)
            {
                for (int j = boxColStart; j < boxColStart + sqrt; j++)
                {
                    if (board[i, j] == num)
                        return false;
                }
            }

            return true;
        }
    }
}


