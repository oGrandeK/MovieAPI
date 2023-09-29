using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;

namespace MovieAPI.Application.UseCases.UserUseCases;

public class VerifyEmailUseCase : IVerifyEmailUseCase
{
    private readonly IUserRepository _userRepository;

    public VerifyEmailUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Verify(string verificationCode, string email)
    {
        // Verificar codigo enviado com codigo do usuario que esta no banco.
        try
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            user.Email.Verification.Verify(verificationCode);
            await _userRepository.UpdateUserAsync(user);
            return user;
        }
        catch (DomainExceptionValidation ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error stacktrace: {ex.StackTrace}");
            throw;
        }
    }
}