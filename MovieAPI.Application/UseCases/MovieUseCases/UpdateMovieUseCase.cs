using MovieAPI.Application.Interfaces.UseCases.MovieUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.MovieUsecases;

public class UpdateMovieUseCase : IUpdateMovieUseCase
{
    private readonly IMovieRepository _movieRepository;

    public UpdateMovieUseCase(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task Execute(int id, Movie movieData)
    {
        try
        {
            var movie = await _movieRepository.GetMovieDirectorsByIdAsync(id);
            movie.UpdateMovie(movieData.Title, movieData.DirectorId, movieData.Description, movieData.Genre, movieData.DurationInMinutes, movieData.ReleaseDate, movieData.Rating);
            await _movieRepository.UpdateMovieAsync(movie);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
            throw;
        }
    }
}