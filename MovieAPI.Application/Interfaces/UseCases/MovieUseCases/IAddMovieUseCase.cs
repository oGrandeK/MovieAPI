using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

/// <summary>
/// Interface para serviços relacionados a criação de um novo filme.
/// </summary>
public interface IAddMovieUseCase
{
    /// <summary>
    /// Cria um novo <see cref="Movie"/> com base nas informações fornecidas.
    /// </summary>
    /// <param name="movie">As informações do <see cref="Movie"/> a serem usadas para a criação.</param>
    public Task Execute(Movie movie);
}