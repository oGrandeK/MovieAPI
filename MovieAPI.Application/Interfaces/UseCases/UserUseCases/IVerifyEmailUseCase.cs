using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IVerifyEmailUseCase
{
    public bool Verify(string verificationCode, User user);
}