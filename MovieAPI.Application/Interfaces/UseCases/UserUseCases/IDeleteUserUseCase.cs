using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

/// <summary>
/// Interface para serviços relacionados a exclusão de um usuário.
/// <summary>
public interface IDeleteUserUseCase
{
    /// <summary>
    /// Excluí um usuário com base no ID fornecido.
    /// </summary>
    /// <param name="id">O ID do usuário a ser procurado.</param>
    /// <returns>O <see cref="User"/> excluído.</returns>
    public Task<User> Execute(int id);
}