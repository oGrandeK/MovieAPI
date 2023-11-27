namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

/// <summary>
/// Interface para serviços relacionados ao login de usuário.
/// </summary>
public interface ILoginUseCase
{
    /// <summary>
    /// Efetua o login do usuário.
    /// </summary>
    /// <param name="email">O e-mail do usuário.</param>
    /// <param name="password">A senha do usuário.</param>
    /// <returns>Um token JWT.</returns>
    Task<string> Login(string email, string password);
}