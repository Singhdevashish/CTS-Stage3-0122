using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib1
{
   internal class SavingsAccount : Account
    {
        public override void Deposit(double amount)
        {
            Console.WriteLine("Depositing {0} in savings account", amount);
        }

        public override void Withdraw(double amount)
        {
            Console.WriteLine("Withdraw {0} from savings account", amount);
        }
    }
}
