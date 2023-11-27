using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

/// <summary>
/// Interface para serviços relacionados a verificação do e-mail do <see cref="User"/>.
/// </summary>
public interface IVerifyEmailUseCase
{
    /// <summary>
    /// Verifica o e-mail do <see cref="User"/>. 
    /// </summary>
    /// <param name="verificationCode">O código de verificação a ser verificado.</param>
    /// <param name="email">O e-mail que está sendo verificado.</param>
    /// <returns>As informações do <see cref="User"/> que foi verificado.</returns>
    public Task<User> Verify(string verificationCode, string email);
}