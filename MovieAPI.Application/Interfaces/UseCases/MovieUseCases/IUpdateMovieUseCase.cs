using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

public interface IUpdateMovieUseCase
{
    public Task Execute(int id, Movie movieData);
}