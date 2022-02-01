using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order_DIP() { Amount = 500 };
            var card = new DebitCard_DIP() { CardNo = "12345678910121314" };

            //var orderManager = new OrderManagement_DIP();
            //orderManager.PaymentGateway = new VisaPaymentGateway_DIP(); //passing depency to property
            //orderManager.PlaceOrder(order, card);


            //var orderManager = new OrderManagement_DIP();
            //orderManager.PlaceOrder(order, card, new VisaPaymentGateway_DIP()); //passing dependency in method


            var orderManager = new OrderManagement_DIP(new VisaPaymentGateway_DIP());//passing dependency in constructor
            orderManager.PlaceOrder(order, card); 

            Console.ReadKey();
        }
    }
}
