using SendGrid;
using SendGrid.Helpers.Mail;

namespace MovieAPI.Application.Interfaces;

public class SendGridEmailService : IEmailService
{
    private readonly string _sendGridApiKey;

    public SendGridEmailService()
    {
        _sendGridApiKey = Environment.GetEnvironmentVariable("SendGrid") ?? throw new NullReferenceException("Cannot find Send Grid Api Key in Environment Variables");
    }

    public async Task SendEmailAsync(string receiver, string subject, string body)
    {
        var client = new SendGridClient(_sendGridApiKey);
        var from = new EmailAddress("kelvimkauam@gmail.com", "Kelvim Kauam");
        var to = new EmailAddress(receiver);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, null, body);

        var response = await client.SendEmailAsync(msg);
    }
}