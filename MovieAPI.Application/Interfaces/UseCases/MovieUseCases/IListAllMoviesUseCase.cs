using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

public interface IListAllMoviesUseCase
{
    public Task<IEnumerable<Movie>> Execute();
}