using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersAPI
{
    public class Order
    {
        public int OrderId { get; set; }      
        public string ProductName { get; set; }
        public int OrderAmount { get; set; }

        public string CustomerName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }
}
