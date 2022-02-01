using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPDemo
{
    class Order_DIP
    {
        public double Amount { get; set; }
    }
    class DebitCard_DIP
    {
        public string CardNo { get; set; }
    }
    //class OrderManagement_DIP
    //{
    //    public void PlaceOrder(Order order, DebitCard card)
    //    {
    //        Console.WriteLine("Confirming the order");
    //        IPaymentGateway paymentGateway = new VisaPaymentGateway_DIP();
    //        paymentGateway.ChargeCard(card, order.Amount);
    //        Console.WriteLine("Order completed");
    //    }
    //}
    #region PropertyInjection
    //class OrderManagement_DIP
    //{
    //    private IPaymentGateway paymentGateway;
    //    public IPaymentGateway PaymentGateway
    //    {
    //        set { paymentGateway = value; }
    //    }
    //    public void PlaceOrder(Order_DIP order, DebitCard_DIP card)
    //    {
    //        Console.WriteLine("Confirming the order");           
    //        paymentGateway.ChargeCard(card, order.Amount);
    //        Console.WriteLine("Order completed");
    //    }
    //}
    #endregion

    #region MethodInjection
    //class OrderManagement_DIP
    //{

    //    public void PlaceOrder(Order_DIP order, DebitCard_DIP card, IPaymentGateway paymentGateway)
    //    {
    //        Console.WriteLine("Confirming the order");
    //        paymentGateway.ChargeCard(card, order.Amount);
    //        Console.WriteLine("Order completed");
    //    }
    //}
    #endregion

    #region ConstructorInjection
    class OrderManagement_DIP
    {
        private IPaymentGateway paymentGateway;
        public OrderManagement_DIP(IPaymentGateway paymentGateway)
        {
            this.paymentGateway = paymentGateway;
        }
        public void PlaceOrder(Order_DIP order, DebitCard_DIP card)
        {
            Console.WriteLine("Confirming the order");
            paymentGateway.ChargeCard(card, order.Amount);
            Console.WriteLine("Order completed");
        }
    }
    #endregion
    interface IPaymentGateway
    {
        void ChargeCard(DebitCard_DIP card, double amount);
    }
    class VisaPaymentGateway_DIP : IPaymentGateway
    {
        public void ChargeCard(DebitCard_DIP card, double amount)
        {
            Console.WriteLine($"Collecting {amount} from card {card.CardNo}");
        }
    }
}
