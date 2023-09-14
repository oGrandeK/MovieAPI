using MovieAPI.Application.Interfaces.UseCases.MovieUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.MovieUsecases;

public class ListMoviesByNameUseCase : IListMoviesByNameUseCase
{
    private readonly IMovieRepository _movieRepository;

    public ListMoviesByNameUseCase(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<IEnumerable<Movie>> Execute(string name)
    {
        try
        {
            return await _movieRepository.GetMoviesDirectorsByNameAsync(name);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
            throw;
        }
    }
}