using MovieAPI.Application.Interfaces.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MovieAPI.Application.Services;

public class SendGridEmailService : IEmailService
{
    private readonly SendGridConfig _sendGridConfig;
    public SendGridEmailService()
    {
        _sendGridConfig = new SendGridConfig();
    }

    public async Task<bool> SendEmailAsync(string receiver, string subject, string body)
    {
        var client = new SendGridClient(_sendGridConfig.Key);
        var from = new EmailAddress(_sendGridConfig.Email, "oGrandeK");
        var to = new EmailAddress(receiver);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, null, body);

        var response = await client.SendEmailAsync(msg);

        return response.IsSuccessStatusCode ? true : false;
    }
}