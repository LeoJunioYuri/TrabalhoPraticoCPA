using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoFinalCPA;

namespace TrabalhoFinalCPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MazeSolverController : Controller
    {
        [HttpPost]
        public IActionResult SolveMaze([FromBody] int[][] maze)
        {
            List<Tuple<int, int>> path = MazeSolver.SolveMaze(maze);

            if (path.Count == 0)
            {
                return NotFound();
            }

            return Ok(path);
        }
    }
}
