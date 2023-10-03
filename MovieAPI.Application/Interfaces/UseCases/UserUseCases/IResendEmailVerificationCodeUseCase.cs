using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IResendEmailVerificationCodeUseCase
{
    public Task<User> Resend(string email);
}