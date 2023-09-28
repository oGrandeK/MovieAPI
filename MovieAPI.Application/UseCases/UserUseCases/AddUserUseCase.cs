using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Application.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;

namespace MovieAPI.Application.UseCases.UserUseCases;

public class AddUserUseCase : IAddUserUseCase
{
    private readonly IUserRepository _userRepository;

    public AddUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Execute(User user)
    {
        try
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(user.Email.Address);
            if (existingUser != null && !string.IsNullOrEmpty(existingUser.Email.Address)) throw new Exception("Email já cadastrado");
        }
        catch (DomainExceptionValidation)
        {
            var emailService = new SendGridEmailService();
            await emailService.SendEmailAsync(user.Email, "Bem vindo", $"Seu código de acesso {user.Email.Verification.Code}");

            return await _userRepository.CreateUserAsync(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error stacktrace: {ex.StackTrace}");
            throw;
        }

        return user;
    }
}