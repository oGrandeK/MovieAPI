using MovieAPI.Application.Interfaces.UseCases.MovieUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.MovieUsecases;

public class ListAllMoviesUseCase : IListAllMoviesUseCase
{
    private readonly IMovieRepository _movieRepository;

    public ListAllMoviesUseCase(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<IEnumerable<Movie>> Execute()
    {
        try
        {
            return await _movieRepository.GetMoviesDirectorsAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
            throw;
        }
    }
}