//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DIP
//{
//    class Order
//    {
//        public double Amount { get; set; }
//    }
//    class DebitCard
//    {
//        public string CardNo { get; set; }
//    }
//    class OrderManagement
//    {
//        public void PlaceOrder(Order order, DebitCard card)
//        {
//            Console.WriteLine("Confirming the order");
//            var paymentGateWay = new VisaPaymentGateway();
//            paymentGateWay.ChargeCard(card, order.Amount);
//            Console.WriteLine("Order completed");
//        }
//    }
//    class VisaPaymentGateway
//    {
//        public void ChargeCard(DebitCard card, double amount)
//        {
//            Console.WriteLine($"Collecting {amount} from card {card.CardNo}");
//        }
//    }
//}
