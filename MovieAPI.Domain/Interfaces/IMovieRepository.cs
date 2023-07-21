using MovieAPI.Domain.Entities;

namespace MovieAPI.Domain.interfaces;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMoviesDirectorsAsync();
    Task<Movie> GetMovieDirectorsById(int id);
    Task<IEnumerable<Movie>> GetMoviesDirectorsByNameAsync(string movieTitle);
    Task<Movie> CreateMovieAsync(Movie movie);
    Task<Movie> UpdateMovieAsync(Movie movie);
    Task<Movie> DeleteMovieAsync(Movie movie);
}