using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IDeleteUserUseCase
{
    public Task<User> Execute(int id);
}