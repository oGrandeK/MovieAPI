using System.Text.RegularExpressions;

namespace MovieAPI.Domain.ValueObjects;

/// <summary>
/// Representa um objeto de valor que encapsula um endereço de e-mail.
/// </summary>
public class Email : ValueObject
{
    /// <summary>
    /// Padrão de expressão regular para validar o formato do endereço de e-mail.
    /// </summary>
    /// <remarks>
    /// O padrão utiliza uma expressão regular simples para verificar se o formato do e-mail é válido.
    /// </remarks>
    const string Pattern = @"\w+@\w+\.\w+";

    /// <summary>
    /// Obtém o endereço de e-mail.
    /// </summary>
    public string Address { get; private set; }

    /// <summary>
    /// Obtém ou define as informações de verificação associadas ao e-mail.
    /// <summary>
    public Verification Verification { get; set; } = new Verification();

    /// <summary>
    /// Cria uma instância da classe <see cref="Regex"/> para validar o formato do endereço de e-mail.
    /// </summary>
    /// <returns>Uma instância de <see cref="Regex"/> configurada para validar o formato do endereço de e-mail.</returns>
    private static Regex EmailRegex() => new Regex(Pattern);

    /// <summary>
    /// Construtor privado e sem parâmetros para permitir a criação via ORM e serialização.
    /// </summary>
    private Email()
    {

    }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Email"/>.
    /// </summary>
    /// <param name="address">O endereço de e-mail a ser encapsulado.</param>
    /// <exception cref="Exception">Lançada se o endereço de e-mail não atender aos critérios de validação.</exception>
    public Email(string address)
    {
        if (string.IsNullOrEmpty(address)) throw new Exception("E-mail não pode ser nulo ou vazio");

        Address = address.Trim().ToLower();

        if (Address.Length < 5) throw new Exception("E-mail deve conter mais que 5 caracteres");

        if (!EmailRegex().IsMatch(Address)) throw new Exception("E-mail inserido não está com formato válido");
    }

    /// <summary>
    /// Converte implicitamente um objeto <see cref="Email"/> para uma representação de string.
    /// </summary>
    /// <param name="email">O objeto <see cref="Email"/> a ser convertido.</param>
    public static implicit operator string(Email email) => email.ToString();

    /// <summary>
    /// Converte implicitamente uma representação de strin para um objecto <see cref="Email"/>.
    /// </summary>
    /// <param name="address">A representação de string do endereço de e-mail.</param>
    public static implicit operator Email(string address) => new Email(address);

    /// <summary>
    /// Converte o objeto <see cref="Email"/> para uma representação de string.
    /// </summary>
    /// <returns>O endereço de e-mail como uma string.</returns>
    public override string ToString() => Address;

    /// <summary>
    /// Reenvia o código de verificação associado ao e-mail.
    /// </summary>
    public void ResendVerification() => Verification = new Verification();
}