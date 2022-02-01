using System;
using BankLib2;
using System.Reflection;
namespace BankLib2Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //SavingsAccount savings = new SavingsAccount();
            //RegularCustomer regular = new RegularCustomer();
            //regular.PrintDetails();
            //savings.Deposit(10000);


            //CurrentAccount current = new CurrentAccount();
            //PrivilegeCustomer privilege = new PrivilegeCustomer();
            //privilege.PrintDetails();
            //current.Deposit(200000);
            
            //AccountFactory factory = new CurrentAccountFactory();
            AccountFactory factory = GetFactory("BankLib2.SavingsAccountFactory");
            Account account = factory.CreateAccount();
            Customer customer = factory.CreateCustomer();
            account.Deposit(10000);
            customer.PrintDetails();

            Account account1 = factory.CreateAccount();
            Customer customer1 = factory.CreateCustomer();
            account1.Deposit(500);
            customer1.PrintDetails();
        }
        static AccountFactory GetFactory(string name)
        {
            var instance = Activator.CreateInstance(typeof(AccountFactory).Assembly.FullName, name);
            return instance.Unwrap() as AccountFactory;
        }
    }
}
