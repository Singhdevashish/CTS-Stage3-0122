using System;
using BankLib3;
namespace BankLib3Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new SavingAccount();
            account.Deposit(1000);
            account.Withdraw(2000);
        }
    }
}
