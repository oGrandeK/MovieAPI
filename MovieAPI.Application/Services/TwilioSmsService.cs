using Microsoft.VisualBasic;
using MovieAPI.Application.Interfaces;

namespace MovieAPI.Application.Services;

public class TwilioSmsService : ISmsService
{
    private readonly string _accountSid;
    private readonly string _authToken;

    public TwilioSmsService()
    {
        _accountSid = Environment.GetEnvironmentVariable("TwilioSid") ?? throw new NullReferenceException("Twilio SID cannot be found");
        _authToken = Environment.GetEnvironmentVariable("TwilioToken") ?? throw new NullReferenceException("Twilio Token cannot be found");
    }

    public Task SendSms(string from, string to, string message)
    {
        
    }
}