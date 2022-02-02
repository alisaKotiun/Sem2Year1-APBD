using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Server.Services;
using MovieApp.Shared.Models;
using System.Threading.Tasks;


namespace MovieApp.Server.Controllers
{
    [Authorize]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMoviesDbService _dbService;

        public MoviesController(ILogger<MoviesController> logger, IMoviesDbService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(await _dbService.GetMovies());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie([FromRoute] int id)
        {
            return Ok(await _dbService.GetMovie(id));
        }

        [HttpPut]
        public async Task<IActionResult> PutMovie([FromBody] Movie movie)
        {
            await _dbService.UpdateMovie(movie);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostMovie([FromBody] Movie movie)
        {
            await _dbService.AddMovie(movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute]int id)
        {
            await _dbService.DeleteMovie(id);
            return NoContent();
        }
    }
}
