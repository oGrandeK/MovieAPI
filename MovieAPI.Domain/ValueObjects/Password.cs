namespace MovieAPI.Domain.ValueObjects;

public class Password : ValueObject
{
    public string Hash { get; set; }

    private Password()
    {

    }

    public Password(string hash)
    {
        Hash = hash;
    }

    public static implicit operator string(Password password) => password.ToString();
    public static implicit operator Password(string password) => new Password(password);

    public override string ToString() => Hash;
}