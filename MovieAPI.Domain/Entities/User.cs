using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Entities;

public class User : Entity
{
    public Name Name { get; set; }
    public Email Email { get; set; }
    public Password Password { get; set; }
}