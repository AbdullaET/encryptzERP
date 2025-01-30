using System.Net;
using System.Net.Mail;
//using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace encrypzERP.BL.Services
{
    

    public class emailService
    {
        //private readonly IConfiguration _configuration;

        //public emailService(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public async Task SendOtpEmailAsync(string recipientEmail, string subject, string message)
        {
            //var emailSettings = _configuration.GetSection("EmailSettings");

            //var smtpServer = emailSettings["SmtpServer"];
            //var port = int.Parse(emailSettings["Port"]);
            //var senderEmail = emailSettings["SenderEmail"];
            //var senderPassword = emailSettings["SenderPassword"];

            //var smtpClient = new SmtpClient(smtpServer)
            //{
            //    Port = port,
            //    Credentials = new NetworkCredential(senderEmail, senderPassword),
            //    EnableSsl = true
            //};

            //var mailMessage = new MailMessage
            //{
            //    From = new MailAddress(senderEmail),
            //    Subject = subject,
            //    Body = message,
            //    IsBodyHtml = true
            //};

            //mailMessage.To.Add(recipientEmail);

            //await smtpClient.SendMailAsync(mailMessage);
        }
    }

}
