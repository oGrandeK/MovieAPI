using MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.DirectorUseCases;

public class UpdateDirectorUseCase : IUpdateDirectorUseCase
{
    private readonly IDirectorRepository _directorRepository;

    public UpdateDirectorUseCase(IDirectorRepository directorRepository) => _directorRepository = directorRepository;

    public async Task Execute(int id, Director directorData)
    {
        try
        {
            var director = await _directorRepository.GetDirectorMoviesByIdAsync(id);
            director.UpdateName(directorData.Name);
            await _directorRepository.UpdateDirectorAsync(director);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
            throw;
        }
    }
}