using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.UseCases.UserUseCases;

public interface IAddUserUseCase
{
    public Task<User> Execute(User user, IConfiguration options);
}