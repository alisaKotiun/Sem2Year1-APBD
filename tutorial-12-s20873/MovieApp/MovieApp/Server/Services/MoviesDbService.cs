using Microsoft.EntityFrameworkCore;
using MovieApp.Server.Data;
using MovieApp.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Server.Services
{
    public interface IMoviesDbService
    {
        Task<List<Movie>> GetMovies();
        Task AddMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task<Movie> GetMovie(int movieId);
        Task DeleteMovie(int movieId);
    }

    public class MoviesDbService : IMoviesDbService
    {
        private ApplicationDbContext _context;

        public MoviesDbService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddMovie(Movie movie)
        {
            _context.Add(movie);
            return _context.SaveChangesAsync();
        }

        public Task DeleteMovie(int movieId)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == movieId);
            _context.Remove(movie);
            return _context.SaveChangesAsync();
        }

        public Task<Movie> GetMovie(int movieId)
        {
            return _context.Movies.SingleOrDefaultAsync(m => m.Id == movieId);
        }

        public Task<List<Movie>> GetMovies()
        {
            return _context.Movies.OrderBy(m => m.Title).ToListAsync();
        }

        public Task UpdateMovie(Movie movie)
        {
            _context.Attach(movie);
            _context.Entry(movie).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
