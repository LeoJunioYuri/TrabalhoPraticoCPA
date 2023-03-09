using System;

namespace TrabalhoFinalCPA
{
    class SudokuSolver
    {
        private const int SIZE = 9;

        private int[,] board;

        public SudokuSolver(int[,] board)
        {
            this.board = board;
        }

        public int[,] GetBoard()
        {
            return this.board;
        }

        public bool Solve()
        {
            int row = 0;
            int col = 0;

            if (!FindUnassignedLocation(ref row, ref col))
            {
                return true;
            }

            for (int num = 1; num <= SIZE; num++)
            {
                if (IsSafe(row, col, num))
                {
                    board[row, col] = num;

                    if (Solve())
                    {
                        return true;
                    }

                    board[row, col] = 0;
                }
            }

            return false;
        }

        private bool FindUnassignedLocation(ref int row, ref int col)
        {
            for (row = 0; row < SIZE; row++)
            {
                for (col = 0; col < SIZE; col++)
                {
                    if (board[row, col] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool UsedInRow(int row, int num)
        {
            for (int col = 0; col < SIZE; col++)
            {
                if (board[row, col] == num)
                {
                    return true;
                }
            }

            return false;
        }

        private bool UsedInCol(int col, int num)
        {
            for (int row = 0; row < SIZE; row++)
            {
                if (board[row, col] == num)
                {
                    return true;
                }
            }

            return false;
        }

        private bool UsedInBox(int boxStartRow, int boxStartCol, int num)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row + boxStartRow, col + boxStartCol] == num)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsSafe(int row, int col, int num)
        {
            return !UsedInRow(row, num)
                && !UsedInCol(col, num)
                && !UsedInBox(row - row % 3, col - col % 3, num);
        }

        public void PrintBoard()
        {
            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    Console.Write(board[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
