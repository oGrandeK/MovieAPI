namespace MovieAPI.Domain.Validation;

/// <summary>
/// Exceção personalizada para representar erros de validação no domínio.
/// </summary>
public class DomainExceptionValidation : Exception
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="DomainExceptionValidation"/>
    /// </summary>
    /// <param name="error">A mensagem de erro associada à exeção.</param>
    public DomainExceptionValidation(string error) : base(error)
    {

    }

    /// <summary>
    /// Lança uma exceção <see cref="DomainExceptionValidation"/> se a condição for verdadeira.
    /// </summary>
    /// <param name="hasError">A condição do erro.</param>
    /// <param name="error">A mensagem de erro associada à exceção.</param>
    /// <exception cref="DomainExceptionValidation">Exceção lançada se a condição do erro for verdadeira.</exception>
    public static void HasError(bool hasError, string error)
    {
        if (hasError) throw new DomainExceptionValidation(error);
    }
}