namespace MovieAPI.Application.Interfaces;

using System.Net;
using System.Net.Http.Headers;

public interface IEmailService
{
    Task<bool> SendEmailAsync(string receiver, string subject, string body);
}