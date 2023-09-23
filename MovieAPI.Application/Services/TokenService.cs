using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieAPI.Application.Interfaces.Services;
using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Services;

public class TokenService : ITokenService
{
    private readonly Configuration _configuration;

    public TokenService(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration.JwtKey ?? string.Empty);
        var claims = new ClaimsIdentity(new[]
        {
            new Claim(JwtRegisteredClaimNames.Name, user.Email),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        });
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claims,
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}