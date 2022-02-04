using ProductsLibrary1;
using System;
using System.Collections.Generic;

namespace ProductsLibrary1Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Product()
            {
                ID = 10001,
                Name = "iPhone Xs",
                Price = 80000
            };
            p1.AddStock(100);
            p1.Sell(100);


            var custA = new Customer()
            {
                CustomerID = 123,
                Name = "Jojo",
                PhoneNo = "9676516962"
            };
            var custB = new Customer()
            {
                CustomerID = 124,
                Name = "Sam",
                PhoneNo = "9676159623"
            };
            var custC = new Customer()
            {
                CustomerID = 125,
                Name = "Sarah",
                PhoneNo = "9700360748"
            };

            p1.Attach(custA);
            //p1.Attach(custB);
            p1.Attach(custC);
            p1.AddStock(10);
            //foreach (var cust in subscribers)
            //    Console.WriteLine($"Dear {cust.Name}, Product {p1.Name} is now back in stock");

            p1.Sell(10);
            p1.Detach(custC);
            p1.AddStock(100);
        }
    }
}
