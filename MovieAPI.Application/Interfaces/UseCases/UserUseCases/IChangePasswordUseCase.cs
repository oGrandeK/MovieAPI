using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

/// <summary>
/// Interface para serviços relacionados a alteração de senha do usuário.
/// </summary>
public interface IChangePasswordUseCase
{
    /// <summary>
    /// Altera a senha do usuário.
    /// </summary>
    /// <param name="user">O usuário a ter a senha alterada.</param>
    /// <param name="oldPassword">A antiga senha do usuário.</param>
    /// <param name="newPassword">A nova senha do usuário.</param>
    /// <returns>Um <see cref="User"/> com a senha alterada.</returns>
    Task<User> Change(User user, string oldPassword, string newPassword);
}