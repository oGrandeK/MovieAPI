using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

/// <summary>
/// Interface para serviços relacionados a criação de um novo Diretor.
/// </summary>
public interface IAddDirectorUseCase
{
    /// <summary>
    /// Cria um novo <see cref="Director"/> com base nas informações fornecidas.
    /// </summary>
    /// <param name="director">As informações do diretor a serem usadas para a criação.</param>
    public Task Execute(Director director);
}