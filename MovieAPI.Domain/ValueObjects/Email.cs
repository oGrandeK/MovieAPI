using System.Text.RegularExpressions;

namespace MovieAPI.Domain.ValueObjects;

public class Email : ValueObject
{
    const string Pattern = @"\w+@\w+\.\w+";
    public string Address { get; private set; }
    public Verification Verification { get; set; }

    private static Regex EmailRegex() => new Regex(Pattern);

    private Email()
    {
        
    }

    public Email(string address)
    {
        if(string.IsNullOrEmpty(address)) throw new Exception("E-mail não pode ser nulo ou vazio");

        Address = address.Trim().ToLower();

        if(Address.Length < 5) throw new Exception("E-mail deve conter mais que 5 caracteres");

        if(!EmailRegex().IsMatch(Address)) throw new Exception("E-mail inserido não está com formato válido");
    }

    public static implicit operator string(Email email) => email.ToString();
    public static implicit operator Email(string address) => new Email(address);

    public override string ToString() => Address;

    public void ResendVerification() => Verification = new Verification();
}