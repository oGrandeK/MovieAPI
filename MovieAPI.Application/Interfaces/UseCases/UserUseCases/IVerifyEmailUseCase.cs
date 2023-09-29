using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IVerifyEmailUseCase
{
    public Task<User> Verify(string verificationCode, string email);
}