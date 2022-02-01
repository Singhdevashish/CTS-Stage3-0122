using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdPartyPaymentSystem
{
    public class PaymentGateway
    {
        public bool ChargeCard(string jsonCardDetails, double amount)
        {
            return true;
        }
        public string GetPayments()
        {
            return @"
[
    {
        TransactionNo : '1234',
        Last4DigitsOfCard : '1111',
        Amount : 1000
    },
    {
        TransactionNo : '1235',
        Last4DigitsOfCard : '1144',
        Amount : 35000
    },
]
";
        }
    }
}
