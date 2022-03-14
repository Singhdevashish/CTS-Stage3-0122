using System;
using System.Collections.Generic;
using System.Text;

namespace CohortManagement.Core.Settings
{
    public class EmailSettings
    {
        public string SmtpURL { get; set; } 
        public int SmtpPort { get; set; } 
        public string FromEmailAddress { get; set; } 
    }
}
