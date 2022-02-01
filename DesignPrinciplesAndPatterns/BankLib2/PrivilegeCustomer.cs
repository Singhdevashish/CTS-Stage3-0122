using System;

namespace BankLib2
{
    internal class PrivilegeCustomer : Customer
    {
        public override void PrintDetails()
        {
            Console.WriteLine("Privilege customer details");
        }
    }
}
