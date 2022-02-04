namespace NotificaitonService
{
    public interface INotificationService
    {
        void SendNotification(string address, string message);
    }
}
