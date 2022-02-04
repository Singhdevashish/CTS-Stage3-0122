using System;
using System.Collections.Generic;
using System.Text;

namespace ThirdPartyPaymentSystemClient
{
    public class PaymentDetail
    {
        public string TransactionNo { get; set; }
        public string Last4DigitsOfCard { get; set; }
        public double Amount { get; set; }
    }
}
