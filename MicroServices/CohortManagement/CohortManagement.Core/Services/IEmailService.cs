using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CohortManagement.Core.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmailAddress, string subject, string emailBody);
    }
}
