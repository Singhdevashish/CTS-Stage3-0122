using System;
using System.Collections.Generic;

namespace ProductsLibrary1
{
    public class Product : IProductNotification
    {
        private readonly List<Customer> subscribers;
        public Product()
        {
            subscribers = new List<Customer>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public int Quantity { get; set; }

        public void Sell(int quantity)
        {
            if (IsAvailable)
            {
                Quantity -= quantity;
                if (Quantity == 0)
                    IsAvailable = false;
            }
            else
            {
                Console.WriteLine("Out of stock");
            }
        }

        public void AddStock(int quantity)
        {
            Quantity += quantity;
            if (!IsAvailable)
                IsAvailable = true;
            Notify();
        }

        public void Attach(Customer customer)
        {
            subscribers.Add(customer);
        }

        public void Detach(Customer customer)
        {
            var index = subscribers.FindIndex(s => s.CustomerID == customer.CustomerID);
            subscribers.RemoveAt(index);
        }

        public void Notify()
        {
            foreach (var sub in subscribers)
                sub.Notify(this);
        }
    }
}
