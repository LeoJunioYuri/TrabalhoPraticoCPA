using Microsoft.AspNetCore.Mvc;
using TrabalhoFinalCPA;

namespace TrabalhoFinalCPA.Controllers
{
    [ApiController]
    [Route("api/v1/nqueen")]
    public class NQueenController : Controller
    {
        [HttpGet("{n}")]
        public IActionResult Get(int n)
        {
            var solver = new NQueenSolver();
            var board = solver.Solve(n);

            var boardList = Enumerable.Range(0, n)
                .Select(x => Enumerable.Range(0, n)
                    .Select(y => board[x, y])
                    .ToList())
                .ToList();

            return Ok(boardList);
        }
    }
}
