using Microsoft.Extensions.Options;
using MovieAPI.Application.Interfaces.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MovieAPI.Application.Services;

public class SendGridEmailService : IEmailService
{
    private readonly SendGridConfig _sendGridConfig;
    public SendGridEmailService(IOptions<SendGridConfig> sendGridConfig)
    {
        _sendGridConfig = sendGridConfig.Value;
    }

    public async Task<bool> SendEmailAsync(string receiver, string subject, string body)
    {
        var from = new EmailAddress(_sendGridConfig.SendGridEmail, "oGrandeK");
        var client = new SendGridClient(_sendGridConfig.SendGridKey);
        var to = new EmailAddress(receiver);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, null, body);

        var response = await client.SendEmailAsync(msg);

        return response.IsSuccessStatusCode ? true : false;
    }
}