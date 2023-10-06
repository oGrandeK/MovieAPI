using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;
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
    public async Task<IEnumerable<Movie>> GetMoviesDirectorsAsync() => await _context.Movies.Include(x => x.Director).AsNoTracking().ToListAsync();

    public async Task<Movie> GetMovieDirectorsByIdAsync(int id) => await _context.Movies.Include(x => x.Director).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id) ?? throw new DomainExceptionValidation($"Movie Cannot be found by id - {id}");

    public async Task<IEnumerable<Movie>> GetMoviesDirectorsByNameAsync(string movieTitle)
    {
        var names = movieTitle.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var query = _context.Movies.Include(x => x.Director).AsNoTracking();

        foreach (var name in names)
        {
            query = query.Where(x => x.Title.MovieTitle.Contains(name));
        }

        var movies = await query.ToListAsync();

        if (movies.Count.Equals(0)) throw new DomainExceptionValidation($"Movie cannot be found by title - {movieTitle}");

        return movies;
    }

    public async Task<IEnumerable<Movie>> GetMoviesDirectorsByGenreAsync(GenreEnumerator movieGenre)
    {
        return await _context.Movies.Include(x => x.Director).AsNoTracking().Where(x => x.Genre == movieGenre).ToListAsync();
    }

    public async Task<Movie> CreateMovieAsync(Movie movie)
    {
        var movieExist = await MovieExist(movie.Title);

        if (!movieExist)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        throw new DomainExceptionValidation("Movie already exists");
    }

    public async Task<Movie> UpdateMovieAsync(Movie movie)
    {
        await _context.Entry(movie).Reference(m => m.Director).LoadAsync();
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

    public async Task<bool> MovieExist(string movieTitle)
    {
        try
        {
            var existingMovie = await GetMoviesDirectorsByNameAsync(movieTitle);
            return true;
        }
        catch (DomainExceptionValidation)
        {
            return false;
        }
    }
}