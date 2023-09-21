namespace MovieAPI.Application.Interfaces.Services;
public interface IEmailService
{
    Task<bool> SendEmailAsync(string receiver, string subject, string body);
}