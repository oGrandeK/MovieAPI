using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.UserUseCases;

public class ListUserByIdUseCase : IListUserByIdUseCase
{
    private readonly IUserRepository _userRepository;

    public ListUserByIdUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Execute(int id)
    {
        try
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error stacktrace: {ex.StackTrace}");
            throw;
        }
    }
}