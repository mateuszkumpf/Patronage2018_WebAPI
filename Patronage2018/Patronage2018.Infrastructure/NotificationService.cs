using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Patronage2018.Application.Interfaces;
using Patronage2018.Application.Notifications.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Patronage2018.Infrastructure
{
    public class NotificationService : INotificationService
    {
        private readonly MailSettings _settings;

        public NotificationService(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendAsync(Message message)
        {
            var fromAddress = new MailAddress(_settings.From, "From Name");
            var toAddress = new MailAddress(_settings.To, "To Name");


            var smtp = new SmtpClient
            {
                Host = _settings.Host,
                Port = _settings.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, _settings.Password),
                Timeout = 20000
            };

            using (var mailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = message.Subject,
                Body = message.Body
            })
            {
                await smtp.SendMailAsync(mailMessage);
            }
        }
    }
}
