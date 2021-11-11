using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieyOMDBAPI.Models;
using MovieyOMDBAPI.Repository;

namespace MovieyOMDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository repo;

        public MovieController(IMovieRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repo.GetMovie());
        }

        [HttpPost]
        public IActionResult Post(Movie movie)
        {
            repo.AddMovie(movie);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            repo.DeleteMovie(id);
            return Ok();

        }
    }
}
