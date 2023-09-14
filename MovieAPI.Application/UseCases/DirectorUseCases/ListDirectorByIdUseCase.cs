using MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.DirectorUseCases;

public class ListDirectorByIdUseCase : IListDirectorByIdUseCase
{
    private readonly IDirectorRepository _directorRepository;

    public ListDirectorByIdUseCase(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task<Director> Execute(int id)
    {
        try
        {
            return await _directorRepository.GetDirectorMoviesByIdAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
            throw;
        }
    }
}