using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

/// <summary>
/// Interface para serviços relacionados a listagem de diretores pelo nome fornecido.
/// </summary>
public interface IListDirectorsByNameUseCase
{
    /// <summary>
    /// Lista todos os <see cref="Director"/> com base no nome fornecido.
    /// </summary>
    /// <param name="name">O nome do diretor a ser procurado.</param>
    /// <returns>Uma coleção de <see cref="Director"/> com base no nome fornecido.</returns>
    public Task<IEnumerable<Director>> Execute(string name);
}