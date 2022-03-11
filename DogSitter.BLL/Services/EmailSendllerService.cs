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
    public class EmailSendllerService : IEmailSendllerService
    {
        private readonly ILogger<EmailSendllerService> _logger;

        public EmailSendllerService(ILogger<EmailSendllerService> logger)
        {
            this._logger = logger;
        }

        public void SendEmailDefault()
        {
            try
            {
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("alianakass2806@gmail.com", "Название компании");
                message.To.Add("alianakass@icloud.com");
                message.Subject = "Креативный текст сообщения";
                message.Body = "<div style=\"color: red;\">Креативный текст сообщения</div>";
                //message.Attachments.Add(new Attachment(""));

                using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Credentials = new NetworkCredential("alianakass2806@gmail.com", "");
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

        public void SendEmailCustom()
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Название компании", "alianakass2806@gmail.com"));
                message.To.Add(new MailboxAddress("Алёна", "alianakass@icloud.com"));
                message.Subject = "Креативный текст сообщения";
                message.Body = new BodyBuilder() { HtmlBody = "<div style=\"color: green;\">Креативный текст сообщения</div>" }.ToMessageBody();

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("alianakass2806@gmail.com", "");
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
    }
}
