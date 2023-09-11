using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using MovieAPI.Domain.Validation;

namespace MovieAPI.Domain.ValueObjects;

public class Name : ValueObject
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    [JsonConstructor]
    public Name(string firstName, string lastName)
    {
        if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)) throw new DomainExceptionValidation("Primeiro nome ou sobrenome não podem ser nulos ou vazios");

        if(firstName.Length < 3 || lastName.Length < 3) throw new DomainExceptionValidation("Primeiro nome e sobrenome devem conter mais que 2 caracteres");

        if(firstName.Any(ch => char.IsPunctuation(ch)) || lastName.Any(ch => char.IsPunctuation(ch))) throw new DomainExceptionValidation("Primeiro nome e sobrenome não podem conter caracter especial");

        if(firstName.Any(ch => char.IsDigit(ch)) || lastName.Any(ch => char.IsDigit(ch))) throw new DomainExceptionValidation("Primeiro nome e sobrenome não devem conter dígitos");

        FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(firstName.Trim());
        LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lastName.Trim());
    }

    private Name() {}

    public static implicit operator string(Name name) => name.ToString();
    public static implicit operator Name(string fullname) {
        var parts = fullname.Split(" ");

        return new Name(parts[0], parts[1]);
    }

    public override string ToString() => $"{FirstName} {LastName}";
}