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
        public Order()
        {
            
        }
        public void CalculateOrderAmount()
        {
            OrderAmount = UnitPrice * Quantity;
        }

        public double ShippingPrice { get; set; }
        public DateTime ExpectedDelivery { get; set; }

        public double TotalOrderAmount { get; set; }
        public void CalculateAmountPayable()
        {
            CalculateOrderAmount();
            TotalOrderAmount = OrderAmount + ShippingPrice;
        }
        public void Confirm()
        {
            
        }
    }
}
