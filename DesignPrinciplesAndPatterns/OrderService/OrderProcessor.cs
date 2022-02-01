using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{

    public class OrderProcessor : IOrderService
    {
        public bool ConfirmOrder(Order order, Customer customer)
        {
            Console.WriteLine("Confirmed order for Customer : {0}", customer.Name);
            Console.WriteLine("Shipping {0} to address {1}", order.ProductName, customer.Address);
            Console.WriteLine("Total amount payable : {0}", order.GetOrderAmount());
            order.Status = "Confirmed";
            return true;
        }
    }
}
