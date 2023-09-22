using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IAddUserUseCase
{
    public Task<User> Execute(User user);
}