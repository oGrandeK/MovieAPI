using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

/// <summary>
/// Interface para serviços relacionados a listagem de usuários pelo nome fornecido.
/// </summary>
public interface IListUsersByNameUseCase
{
    /// <summary>
    /// Retorna lista de usuários com base no nome fornecido.
    /// </summary>
    /// <param name="fullname">O nome completo separado por espaço do usuário a ser procurado.</param>
    /// <returns>Uma coleção de <see cref="User"/> com base no nome completo fornecido.</returns>
    public Task<IEnumerable<User>> Execute(string fullname);
}