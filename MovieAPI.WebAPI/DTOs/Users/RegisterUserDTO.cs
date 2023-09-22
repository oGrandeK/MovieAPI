using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.WebAPI.DTOs.Users;

public record RegisterUserDTO(Name Name, string Email, string Password);