using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IUpdateUserUseCase
{
    public Task<User> Execute(int id, User user, string newHash);
}