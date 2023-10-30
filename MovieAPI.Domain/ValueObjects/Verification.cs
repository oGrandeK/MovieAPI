namespace MovieAPI.Domain.ValueObjects;

/// <summary>
/// Representa um objeto de valor que encapsula informações de verificação, como códigos e prazos de expiração.
/// </summary>
public class Verification : ValueObject
{
    /// <summary>
    /// Obtém o código de verificação.
    /// </summary>
    public string Code { get; private set; } = Guid.NewGuid().ToString("N")[0..6].ToUpper();

    /// <summary>
    /// Obtém a data e a hora de expiração do código de verificação.
    /// </summary>
    public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);

    /// <summary>
    /// Obtém ou define a data e a hora em que o código de verificação foi verificado.
    /// </summary>
    public DateTime? VerifiedAt { get; set; } = null;

    /// <summary>
    /// Obtém um valor que indica se o código de verificação está ativo.
    /// </summary>
    /// <returns>true se o código de verificação está ativo; caso contrário false.</returns>
    public bool IsActive => VerifiedAt != null && ExpiresAt == null;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Verification"/>.
    /// </summary>
    public Verification()
    {

    }

    /// <summary>
    /// Verifica se o código de verificação.
    /// </summary>
    /// <param name="code">O código a ser verificado.</param>
    /// <exception cref="Exception">Lançada se o código já foi verificado, expirou ou é inválido.</exception>
    public void Verify(string code)
    {
        if (IsActive) throw new Exception("Este código já foi verificado");

        if (ExpiresAt < DateTime.UtcNow) throw new Exception("Este código já expirou");

        if (!string.Equals(code.Trim(), Code.Trim(), StringComparison.OrdinalIgnoreCase)) throw new Exception("Código de verificação inválido");

        ExpiresAt = null;
        VerifiedAt = DateTime.UtcNow;
    }
}