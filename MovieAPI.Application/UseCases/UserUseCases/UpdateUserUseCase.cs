using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.UserUseCases;

public class UpdateUserUseCase : IUpdateUserUseCase
{
    private readonly IUserRepository _userRepository;

    public UpdateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Execute(int id, User userData, string newHash)
    {
        try
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            user.UpdateUser(userData.Name, userData.Email, newHash);
            await _userRepository.UpdateUserAsync(user);

            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error stacktrace: {ex.StackTrace}");
            throw;
        }
    }
}