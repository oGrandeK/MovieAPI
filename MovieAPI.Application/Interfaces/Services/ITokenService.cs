using MovieAPI.Domain.Entities;

namespace MovieAPI.Application.Interfaces.Services;

/// <summary>
/// Interface para serviços relacionados a geração de tokens jwt.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Gera um novo token.
    /// </summary>
    /// <param name="user">O <see cref="User"/> a ser usado como base pra criação do token.</param>
    /// <returns>Uma cadeia de caracteres contendo o token gerado.</returns>
    public string GenerateToken(User user);
}