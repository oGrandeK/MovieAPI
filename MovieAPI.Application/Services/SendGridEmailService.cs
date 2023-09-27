using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MovieAPI.Application.Interfaces.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MovieAPI.Application.Services;

public class SendGridEmailService : IEmailService
{
    private readonly IConfiguration _sendGridConfig;
    public SendGridEmailService(IConfiguration sendGridConfig)
    {
        _sendGridConfig = sendGridConfig;
    }

    public async Task<bool> SendEmailAsync(string receiver, string subject, string body)
    {
        var from = new EmailAddress(_sendGridConfig["SendGridEmail"], "oGrandeK");
        var client = new SendGridClient(_sendGridConfig["SendGridConfig:SendGridKey"]);
        var to = new EmailAddress(receiver);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, null, body);

        var response = await client.SendEmailAsync(msg);

        return response.IsSuccessStatusCode ? true : false;
    }
}