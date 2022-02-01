using System;
using System.Collections.Generic;

namespace ThirdPartyPaymentSystemClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static void PrintPayments(List<PaymentDetail> payments)
        {
            foreach (var payment in payments)
                Console.WriteLine("{0}\t{1}\t{2}", payment.TransactionNo, payment.Last4DigitsOfCard, payment.Amount);
        }
    }
}
