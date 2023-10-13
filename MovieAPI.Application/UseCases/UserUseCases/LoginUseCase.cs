using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;

namespace MovieAPI.Application.UseCases.UserUseCases;

public class LoginUseCase : ILoginUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly ITokenService _tokenService;

    public LoginUseCase(IUserRepository userRepository, IPasswordService passwordService, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _tokenService = tokenService;
    }

    public async Task<string> Login(string email, string password)
    {
        try
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (!_passwordService.Verify(user.Password.Hash, password))
                throw new Exception($"User or Password are invalid");

            if (!user.Email.Verification.IsActive)
                throw new Exception($"Email not verified");

            var token = _tokenService.GenerateToken(user);

            return token;
        }
        catch (Exception)
        {
            throw;
        }
    }
}