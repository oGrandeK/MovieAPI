namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface ILoginUseCase
{
    Task<string> Login(string email, string password);
}