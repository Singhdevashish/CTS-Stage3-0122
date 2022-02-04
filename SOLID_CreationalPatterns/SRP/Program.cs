using System;

namespace SRP
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                OrderId = 101,
                Amount = 10000,
                OrderDate = DateTime.Now
            };
            //order.Confirm();
            //order.Save();
            //order.Cancel();

            order.Confirm();

            var orderprocessor = new OrderProcessor();
            orderprocessor.Save(order);

            order.Cancel();
        }
    }
}
