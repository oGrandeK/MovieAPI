using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IResendEmailVerificationCodeUseCase
{
    /// <summary>
    /// Interface para serviços relacionados ao reenvio de código de verificação para o e-mail do usuário.
    /// </summary>
    /// <param name="email">O e-mail do usuário a receber o código.</param>
    /// <returns>As informações do usuário.</returns>
    public Task<User> Resend(string email);
}