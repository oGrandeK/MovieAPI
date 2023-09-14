using MovieAPI.Application.Interfaces.UseCases.MovieUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.MovieUsecases;

public class ListMovieByIdUseCase : IListMovieByIdUseCase
{
    private readonly IMovieRepository _movieRepository;

    public ListMovieByIdUseCase(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<Movie> Execute(int id)
    {
        try
        {
            return await _movieRepository.GetMovieDirectorsByIdAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
            throw;
        }
    }
}