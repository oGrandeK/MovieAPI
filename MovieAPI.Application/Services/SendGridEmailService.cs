using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MovieAPI.Application.Interfaces;

public class SendGridEmailService : IEmailService
{
    private readonly string _sendGridApiKey;

    public SendGridEmailService()
    {
        _sendGridApiKey = Environment.GetEnvironmentVariable("SendGrid") ?? throw new NullReferenceException("SendGrid Api Key cannot be found");
    }

    public async Task<bool> SendEmailAsync(string receiver, string subject, string body)
    {
        var client = new SendGridClient(_sendGridApiKey);
        var from = new EmailAddress("kelvimkauam@outlook.com.br", "oGrandeK");
        var to = new EmailAddress(receiver);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, null, body);

        var response = await client.SendEmailAsync(msg);

        return response.IsSuccessStatusCode ? true : false;
    }
}