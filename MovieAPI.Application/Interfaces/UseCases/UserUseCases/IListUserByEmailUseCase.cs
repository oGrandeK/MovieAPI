using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;
/// <summary>
/// Interface para serviços relacionados a listagem do usuário pelo e-mail.
/// </summary>
public interface IListUserByEmailUseCase
{
    /// <summary>
    /// Retorna um único usuário com base no e-mail fornecido.
    /// </summary>
    /// <param name="email">O e-mail do usuário a ser procurado.</param>
    /// <returns>Um <see cref="User"/> com base no e-mail fornecido.</returns>
    public Task<User> Execute(string email);
}