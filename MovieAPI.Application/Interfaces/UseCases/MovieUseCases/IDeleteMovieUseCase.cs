using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.MovieUseCases;

/// <summary>
/// Interface para serviços relacionados a exclusão de um filme.
/// </summary>
public interface IDeleteMovieUseCase
{
    /// <summary>
    /// Exclui um <see cref="Movie"/> com base no ID fornecido.
    /// </summary>
    /// <param name="id">O ID do <see cref="Movie"/> a ser excluído.</param>
    public Task Execute(int id);
}