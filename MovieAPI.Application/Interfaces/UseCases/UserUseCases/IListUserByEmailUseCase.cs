using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IListUserByEmailUseCase
{
    public Task<User> Execute(string email);
}