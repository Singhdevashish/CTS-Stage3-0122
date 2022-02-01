using System;

namespace BankLib2
{
    internal class RegularCustomer : Customer
    {
        public override void PrintDetails()
        {
            Console.WriteLine("Regular customer details");
        }
    }
}
