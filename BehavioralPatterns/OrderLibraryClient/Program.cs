using OrderLibrary;
using System;

namespace OrderLibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                CustomerName = "Jojo",
                OrderId = 101,
                ProductName = "Markers",
                Quantity = 10,
                UnitPrice = 50,
                ShippingAddress = "Hyderabad"
            };
            order.CalculateOrderAmount();
            Console.WriteLine("Order amount : {0}", order.OrderAmount);

            order.CalculateAmountPayable();
            Console.WriteLine("Total amount payable : {0}", order.TotalOrderAmount);

            order.Confirm();
        }
    }
}
