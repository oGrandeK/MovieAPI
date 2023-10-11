using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IRegisterUserUseCase
{
    Task<User> Register(string firstName, string lastName, string email, string password);
}