namespace MovieAPI.Application.Interfaces;

public interface ISmsService
{
    bool SendSms(string from, string to, string body);
}