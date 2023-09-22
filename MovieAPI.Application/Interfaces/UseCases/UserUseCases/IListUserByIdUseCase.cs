using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IListUserByIdUseCase
{
    public Task<User> Execute(int id);
}