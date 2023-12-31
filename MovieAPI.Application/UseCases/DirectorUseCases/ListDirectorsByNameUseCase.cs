using MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.DirectorUseCases;

public class ListDirectorsByNameUseCase : IListDirectorsByNameUseCase
{
    private readonly IDirectorRepository _directorRepository;

    public ListDirectorsByNameUseCase(IDirectorRepository directorRepository) => _directorRepository = directorRepository;

    public async Task<IEnumerable<Director>> Execute(string name)
    {
        try
        {
            return await _directorRepository.GetDirectorsMoviesByNameAsync(name);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
            throw;
        }
    }
}