using MovieAPI.Domain.Entities;

namespace MovieAPI.Domain.interfaces;

/// <summary>
/// Interface para o repositório de diretores.
/// </summary>
//TODO: Verificar quais exceções podem ser lançadas por cada método.
public interface IDirectorRepository
{
    /// <summary>
    /// Obtém todos os diretores com informações sobre seus filmes.
    /// </summary>
    /// <returns>Uma coleção de diretores com detalhes sobre seus filmes.</returns>
    Task<IEnumerable<Director>> GetDirectorsMoviesAsync();

    /// <summary>
    /// Obtém um diretor com informações sobre seus filmes pelo ID.
    /// </summary>
    /// <param name="id">O ID do diretor a ser pesquisado.</param>
    /// <returns>O diretor com detalhes sobre seus filmes.</returns>
    Task<Director> GetDirectorMoviesByIdAsync(int id);

    /// <summary>
    /// Obtém todos os diretores com informações sobre seus filmes pelo nome.
    /// </summary>
    /// <param name="directorName">O nome do diretor a ser pesquisado.</param>
    /// <returns>Uma coleção de diretores com detalhes sobre seus filmes.</returns>
    Task<IEnumerable<Director>> GetDirectorsMoviesByNameAsync(string directorName);

    /// <summary>
    /// Cria um novo diretor.
    /// </summary>
    /// <param name="director">O diretor a ser criado. Consulte <see cref="Director"/> para mais detalhes sobre diretor.</param>
    /// <returns>O diretor recém criado com detalhes de seus filmes.</returns>
    Task<Director> CreateDirectorAsync(Director director);

    /// <summary>
    /// Atualiza as informações do diretor.
    /// </summary>
    /// <param name="director">O diretor com as informações atualizadas. Consulte <see cref="Director"/> para mais detalhes sobre diretor.</param>
    /// <returns>O diretor atualizado com detalhes de seus filmes.</returns>
    Task<Director> UpdateDirectorAsync(Director director);

    /// <summary>
    /// Deleta o diretor.
    /// </summary>
    /// <param name="director">O diretor a ser deletado. Consulte <see cref="Director"/> para mais detalhes sobre diretor.</param>
    /// <returns>O diretor deletado.</returns>
    Task<Director> DeleteDirectorAsync(Director director);
}