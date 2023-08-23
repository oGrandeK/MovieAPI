using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;

namespace MovieAPI.Domain.interfaces;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMoviesDirectorsAsync();
    Task<Movie> GetMovieDirectorsByIdAsync(int id);
    Task<IEnumerable<Movie>> GetMoviesDirectorsByNameAsync(string movieTitle);
    Task<IEnumerable<Movie>> GetMoviesDirectorsByGenreAsync(GenreEnumerator movieGenre);
    Task<Movie> CreateMovieAsync(Movie movie);
    Task<Movie> UpdateMovieAsync(Movie movie);
    Task<Movie> DeleteMovieAsync(Movie movie);
}