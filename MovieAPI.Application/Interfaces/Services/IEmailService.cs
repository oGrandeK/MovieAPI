namespace MovieAPI.Application.Interfaces.Services;

/// <summary>
/// Interface para serviços relacionados ao e-mail.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Envia um e-mail
    /// </summary>
    /// <param name="receiver">O endereço de e-mail do destinatário.</param>
    /// <param name="subject">O assunto do e-mail.</param>
    /// <param name="body">O corpo do e-mail.</param>
    /// <returns>Um booleano indicando se o e-mail foi enviado com sucesso.</returns>
    Task<bool> SendEmailAsync(string receiver, string subject, string body);
}