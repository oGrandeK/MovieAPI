namespace MovieAPI.Domain.ValueObjects;

/// <summary>
/// Representa um objeto de valor que encapsula um hash de senha.
/// </summary>
// TODO: Aprimorar classe.
public class Password : ValueObject
{
    /// <summary>
    /// Obtém ou define um hash para a senha.
    /// </summary>
    public string Hash { get; set; }

    /// <summary>
    /// Construtor vazio em sem parâmetro para permitir a criação via ORM e serialização.
    /// </summary>
    private Password() { }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Password"/>.
    /// </summary>
    /// <param name="hash">O hash da senha.</param>
    // TODO: Adicionar validações para a senha.
    public Password(string hash)
    {
        Hash = hash;
    }

    /// <summary>
    /// Converte implicitamente um objeto <see cref="Password"/> para uma representação de string.
    /// </summary>
    /// <param name="password">O objeto <see cref="Password"/> a ser convertido.</param>
    /// <returns>Uma representação string do objeto <see cref="Password"/>.</returns>
    public static implicit operator string(Password password) => password.ToString();

    /// <summary>
    /// Converte implicitamente uma representação de string em um objeto <see cref="Password"/>.
    /// </summary>
    /// <param name="password">A representação string a ser convertido.</param>
    /// <returns>Uma nova instância de <see cref="Password"/>.</returns>
    public static implicit operator Password(string password) => new Password(password);

    /// <summary>
    /// Converte o objeto <see cref="Password"/> para uma representação de string.
    /// </summary>
    /// <returns>A hash da senha como string.</returns>
    public override string ToString() => Hash;
}