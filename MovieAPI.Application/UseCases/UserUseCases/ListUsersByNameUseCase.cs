using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.UserUseCases;

public class ListUsersByNameUseCase : IListUsersByNameUseCase
{
    private readonly IUserRepository _userRepository;

    public ListUsersByNameUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> Execute(string fullname)
    {
        try
        {
            return await _userRepository.GetUsersByNameAsync(fullname);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error stacktrace: {ex.StackTrace}");
            throw;
        }
    }
}