using MovieAPI.Domain.Validation;

namespace MovieAPI.Domain.ValueObjects;

public class Title : ValueObject
{
    public string MovieTitle { get; private set; }

    public Title(string title)  
    {
        if(string.IsNullOrEmpty(title)) throw new DomainExceptionValidation("Titulo do filme não deve ser nulo ou vazio");

        if(title.Trim().Length < 2 || title.Length > 100) throw new DomainExceptionValidation("Titulo do filme deve conter entre 2 e 100 caracteres");

        if(title.Trim().Any(ch => char.IsPunctuation(ch))) throw new DomainExceptionValidation("Titulo do filme não deve conter caracter especial");

        MovieTitle = title.Trim();
    }

    private Title() {}

    public static implicit operator string(Title title) => title.ToString();
    public static implicit operator Title(string movieTitle) => new Title(movieTitle);

    public override string ToString() => MovieTitle;
}