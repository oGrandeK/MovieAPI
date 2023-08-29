namespace MovieAPI.Application.Interfaces;

public interface ISmsService
{
    void SendSms(string from, string to, string body);
}