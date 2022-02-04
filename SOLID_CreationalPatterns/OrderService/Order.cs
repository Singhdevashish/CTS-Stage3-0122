namespace OrderService
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Status { get; set; }
        public double GetOrderAmount()
        {
            return UnitPrice * Quantity;
        }
    }
}
