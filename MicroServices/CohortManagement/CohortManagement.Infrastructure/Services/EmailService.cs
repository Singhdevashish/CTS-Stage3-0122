using CohortManagement.Core.Services;
using CohortManagement.Core.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CohortManagement.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;
        public EmailService(IOptions<EmailSettings> options)
        {
            this.emailSettings = options.Value;
        }
        public async Task SendEmailAsync(string toEmailAddress, string subject, string emailBody)
        {
            var smtp = new SmtpClient(emailSettings.SmtpURL);
            //smtp.Credentials = new NetworkCredential("", "");
            var message = new MailMessage
            {
                From = new MailAddress(emailSettings.FromEmailAddress),
                Subject = subject,
                IsBodyHtml = true,
                Body = emailBody
            };
            message.To.Add(new MailAddress(toEmailAddress));
            await smtp.SendMailAsync(message);
        }
    }
}
