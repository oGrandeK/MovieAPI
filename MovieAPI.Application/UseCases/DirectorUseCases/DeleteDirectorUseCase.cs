using MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.DirectorUseCases;

public class DeleteDirectorUseCase : IDeleteDirectorUseCase
{
    private readonly IDirectorRepository _directorRepository;

    public DeleteDirectorUseCase(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task Execute(int id)
    {
        try
        {
            var director = await _directorRepository.GetDirectorMoviesByIdAsync(id);
            await _directorRepository.DeleteDirectorAsync(director);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
            throw;
        }
    }
}