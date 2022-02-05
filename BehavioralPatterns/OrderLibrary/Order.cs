using System;

namespace OrderLibrary
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string ShippingAddress { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double OrderAmount { get; set; }

        public string ShippingPolicy { get; set; }
        public double ShippingPrice { get; set; }
        public DateTime ExpectedDelivery { get; set; }

        public double TotalOrderAmount { get; set; }
        private IShippingPolicy shippingContext;
        public Order(IShippingPolicy shippingContext)
        {
            this.shippingContext = shippingContext;
            this.ShippingPrice = shippingContext.ShippingPrice;
        }
        public void CalculateOrderAmount()
        {
            OrderAmount = UnitPrice * Quantity;
        }

      
        public void CalculateAmountPayable()
        {
            CalculateOrderAmount();
            //switch (ShippingPolicy)
            //{
            //    case "Regular": ShippingPrice = 50; break;
            //    case "Express": ShippingPrice = 100; break;
            //}
            TotalOrderAmount = OrderAmount + ShippingPrice;
        }
        public void Confirm(IShippingPolicy shippingPolicy=null)
        {
            if (shippingPolicy != null)
                this.shippingContext = shippingPolicy;
            shippingContext.AttachPolicy(this);
            //switch (ShippingPolicy)
            //{
            //    case "Regular": ExpectedDelivery = DateTime.Now.AddDays(3); break;
            //    case "Express": ExpectedDelivery = DateTime.Now.AddDays(1); break;
            //}
            Console.WriteLine("Order Id = {0}", OrderId);
            Console.WriteLine("Customer Name = {0}", CustomerName);
            Console.WriteLine("Amount payable = {0}", TotalOrderAmount);
            Console.WriteLine("Shipping charges = {0}", ShippingPrice);
            Console.WriteLine("Expected delivery = {0}", ExpectedDelivery.ToShortDateString());
            
        }
    }

    public interface IShippingPolicy
    {
        string DeliveryPartnerName { get; set; }
        int ShippingPrice { get; set; }
        int NoOfDaysToShip { get; set; }
        void AttachPolicy(Order order);
    }

    public class FreeShipping : IShippingPolicy
    {
        public string DeliveryPartnerName { get; set; }
        public int ShippingPrice { get; set; }
        public int NoOfDaysToShip { get; set; }

        public void AttachPolicy(Order order)
        {
            order.ShippingPrice = ShippingPrice;
            order.ExpectedDelivery = DateTime.Now.AddDays(NoOfDaysToShip);
        }

        public FreeShipping()
        {
            DeliveryPartnerName = "DHL";
            ShippingPrice = 0;
            NoOfDaysToShip = 7;
        }
    }

    public class ExpressShipping : IShippingPolicy
    {
        public string DeliveryPartnerName { get; set; }
        public int ShippingPrice { get; set; }
        public int NoOfDaysToShip { get; set; }

        public void AttachPolicy(Order order)
        {
            order.ShippingPrice = ShippingPrice;
            order.ExpectedDelivery = DateTime.Now.AddDays(NoOfDaysToShip);
        }

        public ExpressShipping()
        {
            DeliveryPartnerName = "DHL";
            ShippingPrice = 100;
            NoOfDaysToShip = 1;
        }
    }

    public class RegularShipping : IShippingPolicy
    {
        public string DeliveryPartnerName { get; set; }
        public int ShippingPrice { get; set; }
        public int NoOfDaysToShip { get; set; }

        public void AttachPolicy(Order order)
        {
            order.ShippingPrice = ShippingPrice;
            order.ExpectedDelivery = DateTime.Now.AddDays(NoOfDaysToShip);
        }

        public RegularShipping()
        {
            DeliveryPartnerName = "DHL";
            ShippingPrice = 50;
            NoOfDaysToShip = 3;
        }
    }
}
