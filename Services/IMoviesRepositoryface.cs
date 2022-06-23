
using Movies_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_API.Services
{
    public interface IMoviesRepositoryface
    {

        Task<bool> MovieExistsByID(int Id);
        Task<bool> MovieNameExist(string Title);
        Task<bool> CreateMovie(Movie Movie);
        Task<bool> DeleteMovie(Movie Movie);
        Task<Movie> GetMovie(int Id);
        Task<Movie> GetMovie(string Title);
        Task<Movie> GetMovieYear(string YearofRelease);
        Task<Movie> GetMovieGenre(string Genre);
        Task<ICollection<Movie>> GetMovies();





    }
}
