using System;

namespace NotificaitonService
{
    public class SmsNotificationService : INotificationService
    {
        public void SendNotification(string address, string message)
        {
            Console.WriteLine("Sms sent to {0}", address);
            Console.WriteLine("Message : {0}", message);
        }
    }
}
