namespace PaymentService
{
    public interface IPaymentService
    {
        bool ChargeCard(Card card, double amount);
    }
}
