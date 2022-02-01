using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService
{

    public class StripePaymentGateway : IPaymentService
    {
        public bool ChargeCard(Card card, double amount)
        {
            Console.WriteLine("Collecting {0} from card no {1}", amount, card.CardNo);
            return true;
        }
    }
}
