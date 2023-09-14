using MovieAPI.Application.Interfaces.UseCases.MovieUseCases;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.MovieUsecases;

public class DeleteMovieUseCase : IDeleteMovieUseCase
{
    private readonly IMovieRepository _movieRepository;

    public DeleteMovieUseCase(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task Execute(int id)
    {
        try
        {
            var movie = await _movieRepository.GetMovieDirectorsByIdAsync(id);
            await _movieRepository.DeleteMovieAsync(movie);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
            throw;
        }
    }
}