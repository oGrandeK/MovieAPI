using MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.DirectorUseCases;

public class ListDirectorByIdUseCase : IListDirectorByIdUseCase
{
    private readonly IDirectorRepository _directorRepository;

    public ListDirectorByIdUseCase(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task Execute(int id)
    {
        try
        {
            var director = await _directorRepository.GetDirectorMoviesByIdAsync(id) ?? null;
            if(director is null) throw new Exception($"Não foi possível encontrar o diretor com o id {id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
        }
    }
}