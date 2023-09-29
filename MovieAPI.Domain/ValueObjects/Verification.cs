namespace MovieAPI.Domain.ValueObjects;

public class Verification : ValueObject
{
    public string Code { get; private set; } = Guid.NewGuid().ToString("N")[0..6].ToUpper();
    public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
    public DateTime? VerifiedAt { get; set; } = null;
    public bool IsActive => VerifiedAt != null && ExpiresAt == null;

    public Verification()
    {

    }

    public void Verify(string code)
    {
        if (IsActive) throw new Exception("Este código já foi verificado");

        if (ExpiresAt < DateTime.UtcNow) throw new Exception("Este código já expirou");

        if (!string.Equals(code.Trim(), Code.Trim(), StringComparison.OrdinalIgnoreCase)) throw new Exception("Código de verificação inválido");

        ExpiresAt = null;
        VerifiedAt = DateTime.UtcNow;
    }
}