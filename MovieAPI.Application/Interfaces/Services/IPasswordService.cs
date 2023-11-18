namespace MovieAPI.Application.Interfaces.Services;

/// <summary>
/// Interface para serviços relacionados as senhas.
/// </summary>
public interface IPasswordService
{
    /// <summary>
    /// Gera um novo hash.
    /// </summary>
    /// <param name="password">A cadeia de caracteres a ser hasheada.</param>
    /// <returns>Uma cadeia de caracteres hasheadas.</returns>
    public string Hash(string password);

    /// <summary>
    /// Verifica se a senha tem o mesmo hash.
    /// </summary>
    /// <param name="hash">A senha a ser verificada.</param>
    /// <param name="password">O hash a ser comparado.</param>
    /// <returns>Um boolenado indicando se a verificação foi bem-sucedida. </returns>
    public bool Verify(string hash, string password);
}