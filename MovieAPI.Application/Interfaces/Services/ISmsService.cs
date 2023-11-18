namespace MovieAPI.Application.Interfaces.Services;

/// <summary>
/// Interface para serviços relacionados ao envio de SMS.
/// </summary>
public interface ISmsService
{
    /// <summary>
    /// Envia um novo SMS.
    /// </summary>
    /// <param name="from">O número de telefone que enviará o SMS.</param>
    /// <param name="to">O número de telefone que receberá o SMS.</param>
    /// <param name="body">A mensagem que será enviada pelo SMS.</param>
    void SendSms(string from, string to, string body);
}