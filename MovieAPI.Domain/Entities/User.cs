using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Entities;

public class User : Entity
{
    public Name Name { get; set; }
    public Email Email { get; set; }
    public Password Password { get; set; }

    private User()
    {

    }

    public User(Name name, string email, string hashedPassword)
    {
        Name = name;
        Email = email;
        Password = hashedPassword;
    }

    public void UpdateUser(string fullname, string email, string hash)
    {
        var names = fullname.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        Name = new Name(names[0], names[1]);
        Email = email;
        Password = hash;
    }

    public void UpdatePassword(string hash)
    {
        Password = hash;
    }
}