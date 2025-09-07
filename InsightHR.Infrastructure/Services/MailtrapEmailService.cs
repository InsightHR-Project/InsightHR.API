using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class MailtrapEmailService : IEmailService
{
    private readonly IConfiguration _config;

    public MailtrapEmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var host = _config["Mailtrap:Host"];
        var port = int.Parse(_config["Mailtrap:Port"]);
        var username = _config["Mailtrap:Username"];
        var password = _config["Mailtrap:Password"];
        var fromEmail = _config["Mailtrap:FromEmail"];

        using var client = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(username, password),
            EnableSsl = true
        };

        var mail = new MailMessage(fromEmail, to, subject, body);
        await client.SendMailAsync(mail);
    }
}
