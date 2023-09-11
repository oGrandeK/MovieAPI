using MovieAPI.Domain.interfaces;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Entities;

public class User : Entity
{
    private readonly IPasswordService _passwordService;

    public Name Name { get; set; }
    public Email Email { get; set; }
    public Password Password { get; set; }

    private User()
    {
        
    }

    public User(IPasswordService passwordService ,string name, string email, string password)
    {
        _passwordService = passwordService;

        Password = _passwordService.Hash(password);
    }
}