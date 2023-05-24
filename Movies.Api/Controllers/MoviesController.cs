using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Models;
using Movies.Api.Services;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {
           var newMovie = _movieService.CreateAsync(movie);
            return Ok(newMovie);
        }

        //[HttpGet]
        //public IActionResult GetMovies()
        //{
            
        //}

        

    }
}
