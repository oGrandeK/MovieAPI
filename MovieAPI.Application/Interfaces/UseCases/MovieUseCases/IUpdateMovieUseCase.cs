using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

/// <summary>
/// Interface para serviços relacionados a atualização de filmes.
/// </summary>
public interface IUpdateMovieUseCase
{
    /// <summary>
    /// Atualiza o filme com base no ID fornecido.
    /// </summary>
    /// <param name="id">O ID do filme a ser atualizado.</param>
    /// <param name="movieData">As novas informações do filme.</param>
    public Task Execute(int id, Movie movieData);
}