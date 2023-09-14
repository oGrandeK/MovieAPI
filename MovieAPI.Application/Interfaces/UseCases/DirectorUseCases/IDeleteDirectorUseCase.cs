namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

public interface IDeleteDirectorUseCase
{
    public Task Execute(int id);
}