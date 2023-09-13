using MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.DirectorUseCases;

public class ListAllDirectorsUseCase : IListAllDirectorsUseCase
{
    private readonly IDirectorRepository _directorRepository;

    public ListAllDirectorsUseCase(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task Execute()
    {
        try
        {
            await _directorRepository.GetDirectorsMoviesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
        }
    }
}