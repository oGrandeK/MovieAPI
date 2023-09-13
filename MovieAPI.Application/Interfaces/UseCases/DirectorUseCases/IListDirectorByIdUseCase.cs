namespace MovieAPI.Application.Interfaces.UseCases.DirectorUseCases;

public interface IListDirectorByIdUseCase
{
    public Task Execute(int id);
}