using Microsoft.AspNetCore.Mvc;
using Oglondanko.Infrastructure.Commands.Movies;
using Oglondanko.Infrastructure.Services;

namespace Oglondanko.Api.Controllers
{
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
                _movieService = movieService;
        }


        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var movies = await _movieService.BrowseAsync(name);

            return Json(movies);
        }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> Get(Guid movieId)
        {
            var movie = await _movieService.GetAsync(movieId);

            if(movie == null)
            {
                return NotFound();
            }
            
            return Json(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateMovie command)
        {
            command.MovieId = Guid.NewGuid();
            await _movieService.CreateAsync(command.MovieId, command.Title, command.Description, command.FilmwebURL, command.WatchScore);
            foreach(string vodName in command.VodName)
            {
            await _movieService.AddVodLinkAsync(command.MovieId, vodName, command.VodLink.First());
            }
            return Created($"/movies/{command.MovieId}", null);
        }

        
        [HttpPut("{movieId}")]
        public async Task<IActionResult> Put(Guid movieId, [FromBody]UpdateMovie command)
        {
            await _movieService.UpdateAsync(command.MovieId, command.Title, command.Description, command.FilmwebURL, command.WatchScore);

            return NoContent();
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> Delete(Guid movieId)
        {
            await _movieService.DeleteAsync(movieId);

            return NoContent();
        }

    }
}