using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

/// <summary>
/// Interface para serviços relacionados a atualização de diretores.
/// </summary>
public interface IUpdateDirectorUseCase
{
    /// <summary>
    /// Atualiza as informações de um diretor pelo ID fornecido.
    /// </summary>
    /// <param name="id">O ID do <see cref="Director"/> a ser procurado.</param>
    /// <param name="directorData">As novas informações do diretor.</param>
    public Task Execute(int id, Director directorData);
}