using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

public interface IListAllDirectorsUseCase
{
    public Task<IEnumerable<Director>> Execute();
}