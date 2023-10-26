using System.Globalization;
using System.Text.Json.Serialization;
using MovieAPI.Domain.Validation;

namespace MovieAPI.Domain.ValueObjects;

/// <summary>
/// Representa um objeto de valor que encapsula um nome composto por um primeiro nome e um sobrenome.
/// </summary>
public class Name : ValueObject
{
    /// <summary>
    /// Obtém o primeiro nome.
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Obtém o sobrenome.
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Name"/>.
    /// </summary>
    /// <param name="firstName">O primeiro nome.</param>
    /// <param name="lastName">O sobrenome.</param>
    /// <exception cref="DomainExceptionValidation">Lançada se os critérios de validação não forem atendidos.</exception>
    [JsonConstructor]
    public Name(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)) throw new DomainExceptionValidation("Primeiro nome ou sobrenome não podem ser nulos ou vazios");

        if (firstName.Length < 3 || lastName.Length < 3) throw new DomainExceptionValidation("Primeiro nome e sobrenome devem conter mais que 2 caracteres");

        if (firstName.Length > 100 || lastName.Length > 100) throw new DomainExceptionValidation("Primeiro nome e sobrenome devem conter menos que 100 caracterers");

        if (firstName.Any(ch => char.IsPunctuation(ch)) || lastName.Any(ch => char.IsPunctuation(ch))) throw new DomainExceptionValidation("Primeiro nome e sobrenome não podem conter caracter especial");

        if (firstName.Any(ch => char.IsDigit(ch)) || lastName.Any(ch => char.IsDigit(ch))) throw new DomainExceptionValidation("Primeiro nome e sobrenome não devem conter dígitos");

        FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(firstName.Trim());
        LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lastName.Trim());
    }

    /// <summary>
    /// Construtor privado sem parâmetros para permitir a criação via ORM ou serialização.
    /// </summary>
    private Name() { }

    /// <summary>
    /// Converte implicitamente um objeto <see cref="Name"/> para uma representação de string.
    /// </summary>
    /// <param name="name">O objeto <see cref="Name"/> a ser convertido.</param>
    /// <returns>O nome completo e formatado como uma string.</returns>
    public static implicit operator string(Name name) => name.ToString();

    /// <summary>
    /// Converte implicitamente uma representação de string para um objeto <see cref="Name"/>.
    /// </summary>
    /// <param name="fullname">A representação de string do nome completo.</param>
    /// <returns>Uma nova instância de <see cref="Name"/>.</returns>
    public static implicit operator Name(string fullname)
    {
        var parts = fullname.Split(" ");

        return new Name(parts[0], parts[1]);
    }

    /// <summary>
    /// Converte o objeto <see cref="Name"/> para uma representação de string.
    /// </summary>
    /// <returns>O nome completo e formatado como uma string.</returns>
    public override string ToString() => $"{FirstName} {LastName}";
}