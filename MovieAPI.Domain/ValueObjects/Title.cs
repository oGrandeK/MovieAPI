using System.Text.Json.Serialization;
using MovieAPI.Domain.Validation;

namespace MovieAPI.Domain.ValueObjects;

/// <summary>
/// Representa um objeto de valor que encapsula um título de filme.
/// </summary>
public class Title : ValueObject
{
    /// <summary>
    /// Obtém o título do filme.
    /// </summary>
    public string MovieTitle { get; private set; }

    /// <summary>
    /// Inicializa uma nova classe <see cref="Title"/>.
    /// </summary>
    /// <param name="movieTitle">O título do filme a ser encapsulado.</param>
    /// <exception cref="DomainExceptionValidation">Lançada se os critérios de validação não forem atendidos.</exception>
    [JsonConstructor]
    public Title(string movieTitle)
    {
        if (string.IsNullOrEmpty(movieTitle)) throw new DomainExceptionValidation("Titulo do filme não deve ser nulo ou vazio");

        if (movieTitle.Trim().Length < 2 || movieTitle.Length > 100) throw new DomainExceptionValidation("Titulo do filme deve conter entre 2 e 100 caracteres");

        if (movieTitle.Trim().Any(ch => char.IsPunctuation(ch))) throw new DomainExceptionValidation("Titulo do filme não deve conter caracter especial");

        MovieTitle = movieTitle.Trim();
    }

    /// <summary>
    /// Construtor privado e sem parâmetros para permitir a criação via ORM e serialização. 
    /// </summary>
    private Title() { }

    /// <summary>
    /// Converte implicitamente um objeto de valor <see cref="Title"/> para uma representação de string.
    /// </summary>
    /// <param name="title">O objeto <see cref="Title"/> a ser convertido.</param>
    /// <returns>Uma representação string do objeto <see cref="Title"/>.</returns>
    public static implicit operator string(Title title) => title.ToString();

    /// <summary>
    /// Converte implicitamente uma repsentação de string em um novo objeto <see cref="Title"/>.
    /// </summary>
    /// <param name="movieTitle">A representação de string a ser convertida.</param>
    /// <returns>Uma nova instância de <see cref="Title"/>.</returns>
    public static implicit operator Title(string movieTitle) => new Title(movieTitle);

    /// <summary>
    /// Converte o objeto <see cref="Title"/> para uma representação de string.
    /// </summary>
    /// <returns>O título do filme como string.</returns>
    public override string ToString() => MovieTitle;
}