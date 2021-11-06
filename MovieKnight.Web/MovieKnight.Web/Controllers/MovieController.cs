using Microsoft.AspNetCore.Mvc;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.BusinessLayer.Services.MovieService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieKnight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieService.GetMovies();
            return Ok(movies);
        }

        [HttpGet]
        [Route("getRecommendedMovie")]
        public async Task<IActionResult> GetRecommendedMovie()
        {
            var movies = (await _movieService.GetMovies()).ToList();
            return Ok(movies[0]);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(Guid id)
        {
            var movie = await _movieService.GetMovieFromImdb(id);
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieDto movieDto)
        {
            var added = await _movieService.AddMovie(movieDto);
            if (added == null)
                return BadRequest();
            return Ok(added);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            bool deleted = await _movieService.DeleteMovie(id);
            return Ok(deleted);
        }
    }
}
