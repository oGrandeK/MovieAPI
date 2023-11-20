namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

/// <summary>
/// Interface para serviços relacionados a exclusão de um diretor.
/// </summary>
public interface IDeleteDirectorUseCase
{
    /// <summary>
    /// Exclui um diretor com base no ID fornecido.
    /// </summary>
    /// <param name="id">O ID do diretor a ser excluído.</param>
    public Task Execute(int id);
}