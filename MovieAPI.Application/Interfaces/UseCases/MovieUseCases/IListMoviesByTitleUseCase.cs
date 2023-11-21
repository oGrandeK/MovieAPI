using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

/// <summary>
/// Interface para serviços relacionados a listagem de filmes pelo título.
/// </summary>
public interface IListMoviesByTitleUseCase
{
    /// <summary>
    /// Retorna os filmes com base no título fornecido.
    /// </summary>
    /// <param name="title">O título do filme a ser pesquisado.</param>
    /// <returns>Uma coleção de <see cref="Movie"/> com base no título fornecido.</returns>
    public Task<IEnumerable<Movie>> Execute(string title);
}