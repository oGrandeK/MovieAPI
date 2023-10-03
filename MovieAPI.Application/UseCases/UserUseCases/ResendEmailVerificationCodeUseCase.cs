using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Application.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;

namespace MovieAPI.Application.UseCases.UserUseCases;

public class ResendEmailVerificationCodeUseCase : IResendEmailVerificationCodeUseCase
{
    private readonly IUserRepository _userRepository;

    public ResendEmailVerificationCodeUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Resend(string email)
    {
        try
        {
            var sendGridEmailService = new SendGridEmailService();
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user.Email.Verification.IsActive) throw new Exception($"Email já foi verificado");
            user.Email.ResendVerification();
            await sendGridEmailService.SendEmailAsync(user.Email, "Seu código de acesso", $"Seu novo código de acesso {user.Email.Verification.Code}");

            await _userRepository.UpdateUserAsync(user);

            return user;
        }
        catch (DomainExceptionValidation ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error stacktrace: {ex.StackTrace}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error stacktrace: {ex.StackTrace}");
            throw;
        }
    }
}