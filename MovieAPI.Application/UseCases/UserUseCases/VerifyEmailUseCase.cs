using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Validation;

namespace MovieAPI.Application.UseCases.UserUseCases;

public class VerifyEmailUseCase : IVerifyEmailUseCase
{
    public bool Verify(string verificationCode, User user)
    {
        // Verificar codigo enviado com codigo do usuario que esta no banco.
        try
        {
            if (user.Email.Verification.Code != verificationCode)
                return false;
            else
            {
                user.Email.Verification.Verify(verificationCode);
                return true;
            }
        }
        catch (DomainExceptionValidation ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            Console.WriteLine($"Error stacktrace: {ex.StackTrace}");
            throw;
        }
    }
}