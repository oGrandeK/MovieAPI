using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

public interface IListDirectorByNameUseCase
{
    public Task<IEnumerable<Director>> Execute(string name);
}