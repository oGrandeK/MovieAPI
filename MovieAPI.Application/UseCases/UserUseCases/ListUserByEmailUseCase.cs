using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.UserUseCases;

public class ListUserByEmailUseCase : IListUserByEmailUseCase
{
    private readonly IUserRepository _userRepository;

    public ListUserByEmailUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Execute(string email)
    {
        try
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error stacktrace: {ex.StackTrace}");
            throw;
        }
    }
}