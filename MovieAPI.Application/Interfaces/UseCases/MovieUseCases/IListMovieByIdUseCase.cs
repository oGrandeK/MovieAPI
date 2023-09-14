using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

public interface IListMovieByIdUseCase
{
    public Task<Movie> Execute(int id);
}