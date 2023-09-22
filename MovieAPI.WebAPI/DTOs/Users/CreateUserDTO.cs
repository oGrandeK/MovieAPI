using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.WebAPI.DTOs.Users;

public record CreateUserDTO(Name Name, string Email, string Password);