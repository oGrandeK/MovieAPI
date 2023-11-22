using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

/// <summary>
/// Interface para serviços relacionados a listagem de um usuário pelo ID fornecido.
/// </summary>
public interface IListUserByIdUseCase
{
    /// <summary>
    /// Retorna um único usuário com base no ID fornecido.
    /// </summary>
    /// <param name="id">O ID do usuário a ser pesquisado.</param>
    /// <returns>Um único <see cref="User"/> com base no ID fornecido.</returns>
    public Task<User> Execute(int id);
}