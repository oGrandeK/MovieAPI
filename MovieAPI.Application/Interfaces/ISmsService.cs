namespace MovieAPI.Application.Interfaces;

public interface ISmsService
{
    Task SendSms(string from, string to, string message);
}