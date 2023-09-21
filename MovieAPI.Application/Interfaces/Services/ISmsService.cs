namespace MovieAPI.Application.Interfaces.Services;

public interface ISmsService
{
    void SendSms(string from, string to, string body);
}