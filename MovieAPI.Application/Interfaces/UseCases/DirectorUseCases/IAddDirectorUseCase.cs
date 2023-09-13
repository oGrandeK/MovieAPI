using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

public interface IAddDirectorUseCase
{
    public Task Execute(Director director);
}