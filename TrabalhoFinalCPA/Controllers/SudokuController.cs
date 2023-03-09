using Microsoft.AspNetCore.Mvc;

namespace TrabalhoFinalCPA.Controllers
{
    [ApiController]
    [Route("api/v1/sudoku")]
    public class SudokuController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] int[][] board)
        {

            int rows = board.Length;
            int cols = board[0].Length;

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = board[i][j];
                }
            }

            var solver = new SudokuSolver(matrix);
            var solvedBoard = solver.Solve();

            if (!solvedBoard)
            {
                return NotFound("Não foi encontrado solução");
            }

            int[,] solvedMatrix = solver.GetBoard();

            int rowsResolvedMatrix = solvedMatrix.GetLength(0);
            int colsResolvedMatrix = solvedMatrix.GetLength(1);

            int[][] array = new int[rowsResolvedMatrix][];

            for (int i = 0; i < rowsResolvedMatrix; i++)
            {
                array[i] = new int[colsResolvedMatrix];
                for (int j = 0; j < colsResolvedMatrix; j++)
                {
                    array[i][j] = solvedMatrix[i, j];
                }
            }

            return Ok(array);
        }
    }
}
