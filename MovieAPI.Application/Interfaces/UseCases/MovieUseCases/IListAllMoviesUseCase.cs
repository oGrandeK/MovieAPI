using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

/// <summary>
/// Interface para serviços relacionados a listagem de filmes.
/// </summary>
public interface IListAllMoviesUseCase
{
    /// <summary>
    /// Retorna os filmes.
    /// </summary>
    /// <returns>Uma coleção de <see cref="Movie"/>.</returns>
    public Task<IEnumerable<Movie>> Execute();
}