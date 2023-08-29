using Microsoft.VisualBasic;
using MovieAPI.Application.Interfaces;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;

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

    public bool SendSms(string from, string to, string body)
    {
        TwilioClient.Init(_accountSid, _authToken);

        var message = MessageResource.Create(body: body, from: new Twilio.Types.PhoneNumber(from), to: new Twilio.Types.PhoneNumber(to));

        var teste = message.Status;

        return true;
    }
}