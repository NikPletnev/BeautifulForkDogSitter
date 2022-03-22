using DogSitter.BLL.Models;
using DogSitter.DAL.Enums;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Net;
using System.Net.Mail;

namespace DogSitter.BLL.Helpers
{
    public class EmailSendller
    {
        private readonly ILogger<EmailSendller> _logger;

        public EmailSendller(ILogger<EmailSendller> logger)
        {
            this._logger = logger;
        }

        public void SendMessage(UserModel user, string mess, string topic)
        {
            foreach (var c in user.Contacts)
            {
                if (c.ContactType == ContactType.Mail)
                {
                    SendEmailCustom(topic, mess, c.Value);
                    break;
                }
            }
        }

        public void SendEmailCustom(string topic, string mess, string email)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("DogSitter", "dogsitterclub2022@gmail.com"));
                message.To.Add(new MailboxAddress(email, email));
                message.Subject = topic;
                message.Body = new BodyBuilder() { HtmlBody = $"<div style=\"color: green;\">{mess}</div>" }.ToMessageBody();

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("dogsitterclub2022@gmail.com", "devedu2022!");
                    client.Send(message);
                    client.Disconnect(true);
                    _logger.LogInformation("Message sent successfully");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetBaseException().Message);
            }
        }

        //устаревшая библиотека, просто хотела посмотреть разницу
        public void SendEmailDefault(string topic, string mess, string email)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("DogSitterClub2022@gmail.com", "DogSitter");
                message.To.Add(email);
                message.Subject = topic;
                message.Body = $"<div style=\"color: red;\">{mess}</div>";

                using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Credentials = new NetworkCredential("DogSitterClub2022@gmail.com", "devedu2022!");
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(message);
                    _logger.LogInformation("Message sent successfully");

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetBaseException().Message);
            }
        }
    }
}
