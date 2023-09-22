using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IListUsersByNameUseCase
{
    public Task<IEnumerable<User>> Execute(string fullname);
}