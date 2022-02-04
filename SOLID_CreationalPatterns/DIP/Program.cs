using System;

namespace DIP
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order { Amount = 10000 };
            var card = new DebitCard { CardNo = "12345678901011134" };

            //var pg = new VisaPaymentGateway();
            var pg = new MasterPaymentGateway();
            var oms = new OrderManagement(pg);
            oms.PlaceOrder(order, card);
        }
    }
}
