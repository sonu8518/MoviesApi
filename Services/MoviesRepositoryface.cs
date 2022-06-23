
using Microsoft.EntityFrameworkCore;
using Movies_API.Data;
using Movies_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Movies_API.Services
{
    public class MoviesRepositoryface: IMoviesRepositoryface
    {
        private DataContext _DataContext;

        public MoviesRepositoryface(DataContext DataContext)
        {
            _DataContext = DataContext;
        }
        public async Task<bool> MovieExistsByID(int Id)
        {
            return await _DataContext.Movie.AnyAsync(b => b.Id == Id);
        }

        public async Task<bool> MovieNameExist(string Title)
        {
            return await _DataContext.Movie.AnyAsync(b => b.Title == Title);
        }
        public async Task<bool> CreateMovie(Movie Movie)
        {

            await _DataContext.AddAsync(Movie);

            return await Save();
        }

        public async Task<bool> DeleteMovie(Movie Movie)
        {
            _DataContext.Remove(Movie);
            return await Save();
        }

        public async Task<Movie> GetMovie(int Id)
        {
            return await _DataContext.Movie.Where(b => b.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<Movie> GetMovie(string Title)
        {
            return await _DataContext.Movie.Where(b => b.Title == Title).FirstOrDefaultAsync();
        }

        public async Task<Movie> GetMovieYear(string YearofRelease)
        {
            return await _DataContext.Movie.Where(b => b.Title == YearofRelease).FirstOrDefaultAsync();
        }

        public async Task<Movie> GetMovieGenre(string Genre)
        {
            return await _DataContext.Movie.Where(b => b.Title == Genre).FirstOrDefaultAsync();
        }


        public async Task<ICollection<Movie>> GetMovies()
        {
            return await _DataContext.Movie.OrderBy(b => b.Id).ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _DataContext.SaveChangesAsync();
            return saved >= 0 ? true : false;
        }

        public async Task<bool> UpdateMovie(List<int> ID, Movie Movie)
        {
            _DataContext.Update(Movie);


            return await Save();
        }

    }
}
