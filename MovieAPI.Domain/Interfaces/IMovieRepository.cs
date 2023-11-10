using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;

namespace MovieAPI.Domain.interfaces;

/// <summary>
/// Interface para repositório de filmes.
/// </summary>
//TODO: Verificar quais exceções podem ser lançadas por cada método.
public interface IMovieRepository
{
    /// <summary>
    /// Obtém todos os filmes com informações sobre seus diretores.
    /// </summary>
    /// <returns>Uma coleção de filmes com detalhes de seus diretores.</returns>
    Task<IEnumerable<Movie>> GetMoviesDirectorsAsync();

    /// <summary>
    /// Obtém um filme com informações sobre seu diretor pelo ID.
    /// </summary>
    /// <param name="id">O ID do filme a ser pesquisado.</param>
    /// <returns>O filme com detalhes sobre seu diretor.</returns>
    Task<Movie> GetMovieDirectorsByIdAsync(int id);

    /// <summary>
    /// Obtém uma coleção de filmes com informações sobre seus diretores pelo nome do filme.
    /// </summary>
    /// <param name="movieTitle">O nome do filme a ser pesquisado.</param>
    /// <returns>Uma coleção de filmes com detalhes de seus diretores.</returns>
    Task<IEnumerable<Movie>> GetMoviesDirectorsByNameAsync(string movieTitle);

    /// <summary>
    /// Obtém uma coleção de filmes com informações sobre seus diretores pelo gênero do filme.
    /// </summary>
    /// <param name="movieGenre">O gênero do filme a ser pesquisado.</param>
    /// <returns>Uma coleção de filmes com detalhes de seus diretores.</returns>
    Task<IEnumerable<Movie>> GetMoviesDirectorsByGenreAsync(GenreEnumerator movieGenre);

    /// <summary>
    /// Cria um novo filme.
    /// </summary>
    /// <param name="movie">O filme a ser criado. Consulte <see cref="Movie"/> para mais detalhes sobre filme.</param>
    /// <returns>O filme criado.</returns>
    Task<Movie> CreateMovieAsync(Movie movie);

    /// <summary>
    /// Atualiza as informações do filme.
    /// </summary>
    /// <param name="movie">O filme com as informações atualizadas. Consulte <see cref="Movie"/> para mais detalhes sobre filmes.</param>
    /// <returns>O filme atualizado com detalhes sobre seu diretor.</returns>
    Task<Movie> UpdateMovieAsync(Movie movie);

    /// <summary>
    /// Deleta o filme.
    /// </summary>
    /// <param name="movie">O filme a ser deletado. Consulte <see cref="Movie"/> para mais detalhes sobre filmes.</param>
    /// <returns>O filme deletado.</returns>
    Task<Movie> DeleteMovieAsync(Movie movie);

    /// <summary>
    /// Verifica se o filme já existe na base de dados pelo nome do filme.
    /// </summary>
    /// <param name="movieTitle">O nome do filme a ser pesquisado.</param>
    /// <returns>true se o filme existir; caso contrário false.</returns>
    Task<bool> MovieExist(string movieTitle);
}