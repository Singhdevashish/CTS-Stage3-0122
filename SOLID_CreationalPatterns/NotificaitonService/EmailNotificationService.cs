using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificaitonService
{

    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string address, string message)
        {
            Console.WriteLine("Email sent to {0}", address);
            Console.WriteLine("Message : {0}", message);
        }
    }
}
