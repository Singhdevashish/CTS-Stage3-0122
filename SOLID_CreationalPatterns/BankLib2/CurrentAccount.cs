using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib2
{
    internal class CurrentAccount : Account
    {
        public override void Deposit(double amount)
        {
            Console.WriteLine("Depositing {0} in current account", amount);
        }

        public override void Withdraw(double amount)
        {
            Console.WriteLine("Withdraw {0} from current account", amount);
        }
    }
}
