using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.UserUseCases;

public class AddUserUseCase : IAddUserUseCase
{
    private readonly IUserRepository _userRepository;

    public AddUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Execute(User user)
    {
        try
        {
            await _userRepository.CreateUserAsync(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error message: {ex.StackTrace}");
            throw;
        }
    }
}