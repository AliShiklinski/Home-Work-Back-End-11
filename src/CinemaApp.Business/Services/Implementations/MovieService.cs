using CinemaApp.Business.Services.Interfaces;
using CinemaApp.Core.Entities;
using CinemaApp.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly AppDBContext _context;

        public MovieService(AppDBContext context)
        {
            _context = context;
        }

   
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

      
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

      
        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));


            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

      
        public async Task UpdateMovieAsync(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException(nameof(movie));

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.Id))
                    throw new KeyNotFoundException($"Movie with ID {movie.Id} not found.");
            }
        }

        
        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) throw new KeyNotFoundException($"Movie with ID {id} not found.");

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        
        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}

