using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

public interface IListMoviesByNameUseCase
{
    public Task<IEnumerable<Movie>> Execute(string name);
}