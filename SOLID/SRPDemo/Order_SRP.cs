using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPDemo
{
    class Order_SRP
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }

        public void Confirm()
        {
            this.Status = "Confirmed";
            var notification = new SMSNotification();
            notification.SendOrderConfirmedSMS(OrderId);
        }
        public void Cancel()
        {
            this.Status = "Cancel";
            var notification = new SMSNotification();
            notification.SendOrderCancelSMS(OrderId, Amount);
        }
    }
    class SMSNotification
    {
        public void SendOrderConfirmedSMS(int orderId)
        {
            Console.WriteLine($"Order {orderId} is confirmed");
        }
        public void SendOrderCancelSMS(int orderId, double amount)
        {
            Console.WriteLine($"Order {orderId} is confirmed");
            Console.WriteLine($"Order amount {amount} will be refunded to your account");
        }
    }

    class OrderProcessor
    {
        public void Save(Order_SRP order)
        {
            //ADO.NET Code to save order in database
            //1. Create connection
            //2. Create an insert query
            //3. Create command
            //4. Open connection
            //5. Execute query
            //6. Close connection
        }
    }
}
