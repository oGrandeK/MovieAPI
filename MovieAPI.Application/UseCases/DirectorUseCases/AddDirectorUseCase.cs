using MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.DirectorUseCases;

public class AddDirectorUseCase : IAddDirectorUseCase
{
    private readonly IDirectorRepository _directorRepository;

    public AddDirectorUseCase(IDirectorRepository directorRepository)
    {
        _directorRepository = directorRepository;
    }

    public async Task Execute(Director director)
    {
        // TODO: Adicionar método que verifica se já existe esse Diretor dentro do repositorio
        try
        {
            await _directorRepository.CreateDirectorAsync(director);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error source: {ex.Source}");
        }
    }
}