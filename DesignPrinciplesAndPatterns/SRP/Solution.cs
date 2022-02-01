using System;

namespace SRP
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }

        public void Confirm()
        {
            this.Status = "Confirmed";
            var notification = new OrderNotification();
            notification.SendNotification($"{this.OrderId} is confirmed");
        }
        public void Cancel()
        {
            this.Status = "Cancel";
            var notification = new OrderNotification();
            notification.SendNotification($"{this.OrderId} is cancelled. {this.Amount} will be refunded to your account");
        }
    }

    public class OrderNotification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class OrderProcessor
    {
        public void Save(Order order)
        {
            Console.WriteLine($"{order.OrderId} is saved");
        }
    }
}