using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

/// <summary>
/// Interface para serviços relacionados a listagem dos diretores.
/// </summary>
public interface IListAllDirectorsUseCase
{
    /// <summary>
    /// Retorna os diretores.
    /// </summary>
    /// <returns>Uma coleção de <see cref="Director"/>.</returns>
    public Task<IEnumerable<Director>> Execute();
}