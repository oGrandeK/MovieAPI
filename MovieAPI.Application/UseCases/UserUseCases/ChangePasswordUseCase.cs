using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Application.Interfaces.UseCases.UserUseCases;
using MovieAPI.Domain.Entities;
using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.Validation;

namespace MovieAPI.Application.UseCases.UserUseCases;

public class ChangePasswordUseCase : IChangePasswordUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;

    public ChangePasswordUseCase(IUserRepository userRepository, IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
    }

    public async Task<User> Change(User user, string oldPassword, string newPassword)
    {
        if (!_passwordService.Verify(user.Password.Hash, oldPassword))
            throw new DomainExceptionValidation($"Old Password incorret");

        user.UpdatePassword(_passwordService.Hash(newPassword));
        await _userRepository.UpdateUserAsync(user);

        return user;
    }
}