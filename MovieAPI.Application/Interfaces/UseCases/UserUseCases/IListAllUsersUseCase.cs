using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

/// <summary>
/// Interface para serviços relacionados a listagem de usuários.
/// </summary>
public interface IListAllUsersUseCase
{
    /// <summary>
    /// Retorna todos os usuários.
    /// </summary>
    /// <returns>Uma coleção de <see cref="User"/>.</returns>
    public Task<IEnumerable<User>> Execute();
}