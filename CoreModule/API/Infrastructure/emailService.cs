using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmail(string toEmail, string otp)
    {
        var smtpSettings = _configuration.GetSection("SmtpSettings");

        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("ERP System", smtpSettings["FromEmail"]));
        email.To.Add(new MailboxAddress("", toEmail));
        email.Subject = "Your OTP Code";
        email.Body = new TextPart("plain")
        {
            Text = $"Your OTP Code is: {otp}. It is valid for 5 minutes."
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(smtpSettings["Host"], int.Parse(smtpSettings["Port"]), bool.Parse(smtpSettings["EnableSSL"]));
        await smtp.AuthenticateAsync(smtpSettings["Username"], smtpSettings["Password"]);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}
