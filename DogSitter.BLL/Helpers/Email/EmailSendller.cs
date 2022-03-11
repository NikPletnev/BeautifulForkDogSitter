using DogSitter.BLL.Models;
using DogSitter.DAL.Enums;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Helpers
{
    public class EmailSendller
    {
        private readonly ILogger<EmailSendller> _logger;

        public EmailSendller(ILogger<EmailSendller> logger)
        {
            this._logger = logger;
        }

        public void SendMessage(UserModel user, string mess)
        {
            foreach (var c in user.Contacts)
            {
                if (c.ContactType == ContactType.Mail)
                {               
                    SendEmailCustom(mess, c.Value);
                    break;
                }
            }
        }

        public void SendEmailCustom(string mess, string email)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Название компании", "alianakass2806@gmail.com"));
                message.To.Add(new MailboxAddress(email, email));
                message.Subject = mess;
                message.Body = new BodyBuilder() { HtmlBody = $"<div style=\"color: green;\">{mess}</div>" }.ToMessageBody();

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("alianakass2806@gmail.com", "inihog2801");
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
        public void SendEmailDefault(string mess, string email)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("alianakass2806@gmail.com", "Название компании");
                message.To.Add(email);
                message.Subject = mess;
                message.Body = $"<div style=\"color: red;\">{mess}</div>";

                using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Credentials = new NetworkCredential("alianakass2806@gmail.com", "НЕ РАБОТАЕТ БЕЗ ПАРОЛЯ");
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
