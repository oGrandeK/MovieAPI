using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

/// <summary>
/// Interface para serviços relacionados ao registro de usuário.
/// </summary>
public interface IRegisterUserUseCase
{
    /// <summary>
    /// Efetua o registro do usuário.
    /// </summary>
    /// <param name="firstName">O primeiro nome do usuário.</param>
    /// <param name="lastName">O sobrenome do usuário.</param>
    /// <param name="email">O e-mail do usuário.</param>
    /// <param name="password">A senha do usuário.</param>
    /// <returns>Os dados do usuário registrado.</returns>
    Task<User> Register(string firstName, string lastName, string email, string password);
}