using MovieAPI.Application.Interfaces.UseCases.MovieUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.MovieUsecases;

public class ListMoviesByGenreUseCase : IListMoviesByGenreUseCase
{
    private readonly IMovieRepository _movieRepository;

    public ListMoviesByGenreUseCase(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<IEnumerable<Movie>> Execute(GenreEnumerator genre)
    {
        try
        {
            return await _movieRepository.GetMoviesDirectorsByGenreAsync(genre);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
            throw;
        }
    }
}