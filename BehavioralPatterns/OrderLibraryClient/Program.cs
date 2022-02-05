using OrderLibrary;
using System;

namespace OrderLibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var policy1 = new ExpressShipping();
            var order = new Order(policy1)
            {
                CustomerName = "Jojo",
                OrderId = 101,
                ProductName = "Markers",
                Quantity = 10,
                UnitPrice = 50,
                ShippingAddress = "Hyderabad",
                ShippingPolicy = "Express"
            };

           
            order.CalculateOrderAmount();
            Console.WriteLine("Order amount : {0}", order.OrderAmount);

            order.CalculateAmountPayable();
            Console.WriteLine("Total amount payable : {0}", order.TotalOrderAmount);

            order.Confirm(new RegularShipping());
        }
    }
}
