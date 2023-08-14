using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;
using MovieAPI.Infraestructure.Context;

namespace MovieAPI.Infraestructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationContext _context;

    public MovieRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Movie>> GetMoviesDirectorsAsync()
    {
        return await _context.Movies.Include(x => x.Director).AsNoTracking().ToListAsync();
    }

    public async Task<Movie> GetMovieDirectorsByIdAsync(int id)
    {
        return await _context.Movies.Include(x => x.Director).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) ?? throw new DomainExceptionValidation($"Movie Cannot be found by id - {id}");
    }

    public async Task<IEnumerable<Movie>> GetMoviesDirectorsByNameAsync(string movieTitle)
    {
        return await _context.Movies.Include(x => x.Director).AsNoTracking().Where(x => x.Title.MovieTitle.Contains(movieTitle)).ToListAsync();
    }

    public async Task<IEnumerable<Movie>> GetMoviesDirectorsByGenreAsync(string movieGenre)
    {
        return await _context.Movies.Include(x => x.Director).AsNoTracking().Where(x => x.Genre.ToString() == movieGenre).ToListAsync();
    }

    public async Task<Movie> CreateMovieAsync(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        return movie;
    }

    public async Task<Movie> UpdateMovieAsync(Movie movie)
    {
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();

        return movie;
    }

    public async Task<Movie> DeleteMovieAsync(Movie movie)
    {
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return movie;
    }
}