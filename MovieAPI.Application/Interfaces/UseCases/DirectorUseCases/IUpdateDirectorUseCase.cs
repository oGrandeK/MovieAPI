using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

public interface IUpdateDirectorUseCase
{
    public Task Execute(int id, Director directorData);
}