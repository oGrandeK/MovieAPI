using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.Services;

public interface ITokenService
{
    public string GenerateToken(User user);
}