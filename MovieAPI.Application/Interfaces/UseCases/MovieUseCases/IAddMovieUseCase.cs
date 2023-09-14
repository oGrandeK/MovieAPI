using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

public interface IAddMovieUseCase
{
    public Task Execute(Movie movie);
}