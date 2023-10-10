using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IChangePasswordUseCase
{
    Task<User> Change(User user, string oldPassword, string newPassword);
}