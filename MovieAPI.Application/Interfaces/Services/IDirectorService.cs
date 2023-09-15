using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.Services;

public interface IDirectorService
{
    public Task AddDirector(Director directorData);
    public Task<IEnumerable<Director>> ListAllDirectors();
    public Task<Director> ListDirectorById(int id);
    public Task<IEnumerable<Director>> ListDirectorByName(string name);
    public Task UpdateDirector(int id, Director directorData);
    public Task DeleteDirector(int id);
}