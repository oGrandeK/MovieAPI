using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

/// <summary>
/// Interface para serviços relacionados a listagem de um diretor pelo ID fornecido.
/// </summary>
public interface IListDirectorByIdUseCase
{
    /// <summary>
    /// Lista um diretor pelo ID fornecido.
    /// </summary>
    /// <param name="id">O ID a ser procurado.</param>
    /// <returns>Retorna um único <see cref="Director"/> com base no ID fornecido.</returns>
    public Task<Director> Execute(int id);
}