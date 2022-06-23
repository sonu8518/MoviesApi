using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies_API.DTOS;
using Movies_API.Entities;
using Movies_API.Services;

namespace Movies_API.Controllers
{

    [ApiController]

    [Route("api/Movies")]
    public class MovieController : ControllerBase
    {

        private IMoviesRepositoryface _moviesRepositoryface;

        public MovieController(IMoviesRepositoryface moviesRepositoryface)
        {
            _moviesRepositoryface = moviesRepositoryface;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<movieDtos>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAppUsers()
        {
            var movies = await _moviesRepositoryface.GetMovies();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movieDtosList = new List<movieDtos>();

            foreach (var Movie in movies)
            {
                movieDtosList.Add(new movieDtos
                {
                    Id = Movie.Id,
                    Title = Movie.Title,
                    YearofRelease = Movie.YearofRelease




                });
            }

            return Ok(movieDtosList);
        }

        //api//Users/1
        [HttpGet("{Title}")]
        [ProducesResponseType(200, Type = typeof(movieDtos))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetMovie(string Title)
        {
            if (!await _moviesRepositoryface.MovieNameExist(Title))
                return NotFound();

            var Movie = await _moviesRepositoryface.GetMovie(Title);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var movieDtos = new movieDtos()
            {
                Id = Movie.Id,
                Title = Movie.Title,
                YearofRelease= Movie.YearofRelease



            };

            return Ok(movieDtos);
        }
    }
}
