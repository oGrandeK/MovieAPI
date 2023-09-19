using System.Text.Json.Serialization;
using MovieAPI.Domain.Validation;

namespace MovieAPI.Domain.ValueObjects;

public class Title : ValueObject
{
    public string MovieTitle { get; private set; }

    [JsonConstructor]
    public Title(string movieTitle)
    {
        if (string.IsNullOrEmpty(movieTitle)) throw new DomainExceptionValidation("Titulo do filme não deve ser nulo ou vazio");

        if (movieTitle.Trim().Length < 2 || movieTitle.Length > 100) throw new DomainExceptionValidation("Titulo do filme deve conter entre 2 e 100 caracteres");

        if (movieTitle.Trim().Any(ch => char.IsPunctuation(ch))) throw new DomainExceptionValidation("Titulo do filme não deve conter caracter especial");

        MovieTitle = movieTitle.Trim();
    }

    private Title() { }

    public static implicit operator string(Title title) => title.ToString();
    public static implicit operator Title(string movieTitle) => new Title(movieTitle);

    public override string ToString() => MovieTitle;
}