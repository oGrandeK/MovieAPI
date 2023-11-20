using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

/// <summary>
/// Interface para serviços relacionados a criação de um novo Diretor.
/// </summary>
public interface IAddDirectorUseCase
{
    /// <summary>
    /// Cria um novo <see cref="Director"/> com base nas informações passadas.
    /// </summary>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    public Task Execute(Director director);
}