using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

public interface IListDirectorByIdUseCase
{
    public Task<Director> Execute(int id);
}