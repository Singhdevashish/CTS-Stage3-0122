using System;
using System.Collections.Generic;
using System.Text;

namespace BankLib2
{
    public abstract class AccountFactory
    {
        public abstract Account CreateAccount();
        public abstract Customer CreateCustomer();
    }
    internal class SavingsAccountFactory : AccountFactory
    {
        public override Account CreateAccount()
        {
            return new SavingsAccount();
        }

        public override Customer CreateCustomer()
        {
            return new RegularCustomer();
        }
    }

    internal class CurrentAccountFactory : AccountFactory
    {
        public override Account CreateAccount()
        {
            return new CurrentAccount();
        }

        public override Customer CreateCustomer()
        {
            return new PrivilegeCustomer();
        }
    }
}
