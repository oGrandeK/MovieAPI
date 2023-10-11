using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Application.Services;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Application.UseCases.UserUseCases;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly IEmailService _emailService;

    public RegisterUserUseCase(IUserRepository userRepository, IPasswordService passwordService, IEmailService emailService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _emailService = emailService;
    }

    public async Task<User> Register(string firstName, string lastName, string email, string password)
    {
        try
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(email);
            if (existingUser != null && !string.IsNullOrEmpty(existingUser.Email.Address))
                throw new Exception($"Email {email} already in use");
        }
        catch (DomainExceptionValidation)
        {
            var user = new User(new Name(firstName, lastName), email, _passwordService.Hash(password));
            await _userRepository.CreateUserAsync(user);

            await _emailService.SendEmailAsync(user.Email, "Bem vindo", $"Seu código de acesso {user.Email.Verification.Code}");

            return user;
        }

        throw new Exception("Unexpected exception occurred while registering user");
    }
}