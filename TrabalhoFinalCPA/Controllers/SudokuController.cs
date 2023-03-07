using Microsoft.AspNetCore.Mvc;
using TrabalhoFinalCPA;

namespace TrabalhoFinalCPA.Controllers
{
    [ApiController]
    [Route("api/v1/sudoku")]
    public class SudokuController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] int[][] board)
        {
            // Convert jagged array to 2D array
            int[,] board2D = new int[9, 9];
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    board2D[i, j] = board[i][j];
                }
            }

            var solver = new SudokuSolver();
            var solvedBoard = solver.Solve(board2D);

            // Convert 2D array back to jagged array
            int[][] solvedBoardJagged = new int[9][];
            for (int i = 0; i < 9; i++)
            {
                solvedBoardJagged[i] = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    solvedBoardJagged[i][j] = solvedBoard[i, j];
                }
            }

            return Ok(solvedBoardJagged);
        }
    }
}
