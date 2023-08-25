namespace MovieAPI.Application.Interfaces;
using SendGrid;

public interface IEmailService
{
    Task SendEmailAsync(string receiver, string subject, string body);
}