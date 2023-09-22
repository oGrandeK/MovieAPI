using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IListAllUsersUseCase
{
    public Task<IEnumerable<User>> Execute();
}