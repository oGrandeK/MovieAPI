namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

public interface IDeleteMovieUseCase
{
    public Task Execute(int id);
}