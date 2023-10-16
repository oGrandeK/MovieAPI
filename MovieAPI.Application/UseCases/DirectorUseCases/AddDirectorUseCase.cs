using MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;

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
        try
        {
            await _directorRepository.CreateDirectorAsync(director);
        }
        catch (DomainExceptionValidation)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
}