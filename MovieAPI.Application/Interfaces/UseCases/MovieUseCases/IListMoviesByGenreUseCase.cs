using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

/// <summary>
/// Interface para serviços relacionados a listagem de filmes pelo gênero.
/// </summary>
public interface IListMoviesByGenreUseCase
{
    /// <summary>
    /// Retorna os filmes pelo gênero fornecido.
    /// </summary>
    /// <param name="genre">O gênero dos filmes a serem pesquisados.</param>
    /// <returns>Uma coleção de <see cref="Movie"/> com base no gênero fornecido.</returns>
    public Task<IEnumerable<Movie>> Execute(GenreEnumerator genre);
}