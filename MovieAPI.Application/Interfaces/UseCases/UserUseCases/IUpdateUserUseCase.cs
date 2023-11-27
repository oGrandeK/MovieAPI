using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

/// <summary>
/// Interface para serviços relacionados a alteração do usuário.
/// </summary>
public interface IUpdateUserUseCase
{
    /// <summary>
    /// Atualiza as informações do usuário.
    /// </summary>
    /// <param name="id">O ID do usuário a ser buscado.</param>
    /// <param name="user">As novas informações do usuário.</param>
    /// <param name="newHash">Nova senha do usuário.</param>
    /// <returns>O <see cref="User"/> com as informações atualizadas.</returns>
    public Task<User> Execute(int id, User user, string newHash);
}