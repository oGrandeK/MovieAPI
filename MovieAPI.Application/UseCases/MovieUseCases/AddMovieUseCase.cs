using MovieAPI.Application.Interfaces.UseCases.MovieUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.MovieUsecases;

public class AddMovieUseCase : IAddMovieUseCase
{
    private readonly IMovieRepository _movieRepository;

    public AddMovieUseCase(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task Execute(Movie movie)
    {
        // TODO: Criar método que verifica se já existe esse Movie dentro do repositorio
        try
        {
            await _movieRepository.CreateMovieAsync(movie);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
            throw;
        }
    }
}