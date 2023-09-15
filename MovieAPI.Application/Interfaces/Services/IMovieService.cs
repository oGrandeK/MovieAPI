using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;

namespace MovieAPI.Application.Interfaces.Services;

public interface IMovieService
{
    public Task AddMovie(Movie movieData);
    public Task DeleteMovie(int id);
    public Task UpdateMovie(int id, Movie movieData);
    public Task<IEnumerable<Movie>> ListAllMovies();
    public Task<Movie> ListMovieById(int id);
    public Task<IEnumerable<Movie>> ListMoviesByTitle(string title);
    public Task<IEnumerable<Movie>> ListMoviesByGenre(GenreEnumerator genre);
}