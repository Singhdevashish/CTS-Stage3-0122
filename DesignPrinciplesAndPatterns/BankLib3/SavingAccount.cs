using System;

namespace BankLib3
{
    public class SavingAccount : Account
    {
        public override void Deposit(double amount)
        {
            Console.WriteLine("Depositing in savings account : " + amount);
        }

        public override void Withdraw(double amount)
        {
            Console.WriteLine("Withdrawing from savings account : " + amount);
        }
    }
}
