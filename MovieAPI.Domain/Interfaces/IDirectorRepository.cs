using MovieAPI.Domain.Entities;

namespace MovieAPI.Domain.interfaces;

public interface IDirectorRepository
{
    Task<IEnumerable<Director>> GetDirectorsMoviesAsync();
    Task<Director> GetDirectorMoviesByIdAsync(int id);
    Task<IEnumerable<Director>> GetDirectorsMoviesByNameAsync(string directorName);
    Task<Director> CreateDirectorAsync(Director director);
    Task<Director> UpdateDirectorAsync(Director director);
    Task<Director> DeleteDirectorAsync(Director director);
}