using System;
using System.Reflection;
using BankLib1;
namespace BankLib1Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //SavingsAccount savings = new SavingsAccount();
            //savings.Deposit(10000);
            //savings.Withdraw(5000);

            //CurrentAccount current = new CurrentAccount();
            //current.Deposit(100000);
            //current.Withdraw(30000);


            //AccountFactory factory = new SavingsAccountFactory();
            //AccountFactory factory = new FixedDepositAccountFactory();
            //AccountFactory factory = new CurrentAccountFactory();
            
            AccountFactory factory = GetAccount("BankLib1.CurrentAccountFactory");
            Account account = factory.Create();
            account.Deposit(10000);
            account.Withdraw(3500);
        }
        static AccountFactory GetAccount(string accountType)
        {
            Assembly assembly = typeof(AccountFactory).Assembly;
            var instance = Activator.CreateInstance(assembly.FullName, accountType);
            return instance.Unwrap() as AccountFactory;
        }
    }
}
