using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.Services;

/// <summary>
/// Interface para serviços relacionados a diretores de filmes.
/// </summary>
public interface IDirectorService
{
    /// <summary>
    /// Adiciona um novo diretor.
    /// </summary>
    /// <param name="directorData">Os dados do diretor a serem adicionados.</param>
    public Task AddDirector(Director directorData);

    /// <summary>
    /// Lista todos os diretores.
    /// </summary>
    /// <returns>Uma coleção de todos os diretores.</returns>
    public Task<IEnumerable<Director>> ListAllDirectors();

    /// <summary>
    /// Obtém um diretor pelo ID.
    /// </summary>
    /// <param name="id">O ID do diretor a ser obtido.</param>
    /// <returns>O diretor correspondente ao ID.</returns>
    public Task<Director> ListDirectorById(int id);

    /// <summary>
    /// Lista os diretores pelo nome.
    /// </summary>
    /// <param name="name">O nome do diretor a ser pesquisado.</param>
    /// <returns>Uma coleção de <see cref="Director"/> com o nome correspondente.</returns>
    public Task<IEnumerable<Director>> ListDirectorByName(string name);

    /// <summary>
    /// Atualiza os dados de um diretor.
    /// </summary>
    /// <param name="id">O ID do diretor a ser atualizado.</param>
    /// <param name="directorData">Os novos dados do diretor.</param>
    public Task UpdateDirector(int id, Director directorData);

    /// <summary>
    /// Exclui um diretor pelo ID.
    /// </summary>
    /// <param name="id">O ID do diretor a ser excluido.</param>
    public Task DeleteDirector(int id);
}