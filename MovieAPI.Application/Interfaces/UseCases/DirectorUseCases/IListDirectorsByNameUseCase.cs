using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

public interface IListDirectorsByNameUseCase
{
    public Task<IEnumerable<Director>> Execute(string name);
}