using MovieAPI.Domain;

namespace MovieAPI.Domain.ValueObjects;

public class Password : ValueObject
{
    public string Hash { get; set; }

    private Password()
    {
        
    }

    public Password(string password)
    {
        
    }
}