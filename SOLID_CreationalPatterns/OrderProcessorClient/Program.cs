using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrderService;
using NotificaitonService;
using PaymentService;
namespace OrderProcessorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer { Name = "Jojo", Address = "Hyderabad", Email = "Jojo@outlook.com", Phone = "9676516962" };

            var order = new Order { OrderId = 101, ProductName = "Laptop", UnitPrice = 88000, Quantity = 1, Status = "Pending" };

            var card = new Card { CardHolderName = "Jojo", CardNo = "1234567890123456", Cvv = "***", ExpiryMonthYear = "10/2030" };


            IOrderService orderService = new OrderProcessor();
            IPaymentService paymentService = new StripePaymentGateway();
            INotificationService smsNotification = new SmsNotificationService();
            INotificationService emailNotification = new EmailNotificationService();


            if (paymentService.ChargeCard(card, order.GetOrderAmount()))
            {
                if (orderService.ConfirmOrder(order, customer))
                {
                    smsNotification.SendNotification(customer.Phone, "Order confirmed");
                    emailNotification.SendNotification(customer.Email, "Order confirmed");
                }
            }

            Console.ReadKey();

        }
    }
}
