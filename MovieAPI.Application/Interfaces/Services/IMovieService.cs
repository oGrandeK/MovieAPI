using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;

namespace MovieAPI.Application.Interfaces.Services;

/// <summary>
/// Interface para serviços relacionados aos filmes.
/// </summary>
public interface IMovieService
{
    /// <summary>
    /// Adiciona um novo filme.
    /// </summary>
    /// <param name="movieData">Os dados do filme a ser adicionado.</param>
    public Task AddMovie(Movie movieData);

    /// <summary>
    /// Lista todos os filmes.
    /// </summary>
    /// <returns>Uma coleção de todos os filmes.</returns>
    public Task<IEnumerable<Movie>> ListAllMovies();

    /// <summary>
    /// Obtém um filme pelo ID.
    /// </summary>
    /// <param name="id">O ID do filme a ser obtido.</param>
    /// <returns>O filme correspondente ao ID.</returns>
    public Task<Movie> ListMovieById(int id);

    /// <summary>
    /// Lista os filmes pelo título.
    /// </summary>
    /// <param name="title">O título do filme a ser pesquisado.</param>
    /// <returns>Uma coleção de <see cref="Movie"/> com o título correspondente.</returns>
    public Task<IEnumerable<Movie>> ListMoviesByTitle(string title);

    /// <summary>
    /// Lista os filmes pelo gênero.
    /// </summary>
    /// <param name="genre">O gênero do filme a ser pesquisado.</param>
    /// <returns>Uma coleção de <see cref="Movie"/> com o gênero correspondente.</returns>
    public Task<IEnumerable<Movie>> ListMoviesByGenre(GenreEnumerator genre);

    /// <summary>
    /// Atualiza os dados de um filme.
    /// </summary>
    /// <param name="id">O ID do filme a ser atualizado.</param>
    /// <param name="movieData">Os novos dados do filme.</param>
    public Task UpdateMovie(int id, Movie movieData);

    /// <summary>
    /// Excluí o filme pelo ID.
    /// </summary>
    /// <param name="id">O ID do filme a ser excluído.</param>
    public Task DeleteMovie(int id);
}