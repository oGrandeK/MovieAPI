using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

/// <summary>
/// Interface para serviços relacionados a listagem de filme pelo ID.
/// </summary>
public interface IListMovieByIdUseCase
{
    /// <summary>
    /// Retorna um único filme pelo ID fornecido.
    /// </summary>
    /// <param name="id">O ID do filme a ser excluído.</param>
    /// <returns>Um único <see cref="Movie"/>.</returns>
    public Task<Movie> Execute(int id);
}