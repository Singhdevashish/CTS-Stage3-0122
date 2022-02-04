namespace OrderService
{
    public interface IOrderService
    {
        bool ConfirmOrder(Order order, Customer customer);
    }
}
