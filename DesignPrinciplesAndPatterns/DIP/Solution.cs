using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
{
    class Order
    {
        public double Amount { get; set; }
    }
    class DebitCard
    {
        public string CardNo { get; set; }
    }
    class OrderManagement
    {
        private readonly IPaymentGateway paymentGateway;
        public OrderManagement(IPaymentGateway paymentGateway)
        {
            this.paymentGateway = paymentGateway;
        }
        public void PlaceOrder(Order order, DebitCard card)
        {
            Console.WriteLine("Confirming the order");
            //IPaymentGateway paymentGateway = new VisaPaymentGateway();
            paymentGateway.ChargeCard(card, order.Amount);
            Console.WriteLine("Order completed");
        }
    }
    interface IPaymentGateway
    {
        void ChargeCard(DebitCard card, double amount);
    }
    class VisaPaymentGateway : IPaymentGateway
    {
        public void ChargeCard(DebitCard card, double amount)
        {
            Console.WriteLine($"Collecting {amount} from card {card.CardNo}");
        }
        public void ChargeCard(string cardno, string cvv, double amount)
        {
            Console.WriteLine($"Collecting {amount} from card {cardno}");
        }
    }

    class MasterPaymentGateway : IPaymentGateway
    {
        public void ChargeCard(DebitCard card, double amount)
        {
            
        }
    }
}