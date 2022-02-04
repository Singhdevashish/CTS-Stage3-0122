using System;
using System.Collections.Generic;
using System.Text;

namespace BankLib1
{
    public abstract class AccountFactory
    {
        public abstract Account Create();
    }
    internal class SavingsAccountFactory : AccountFactory
    {
        public override Account Create()
        {
            return new SavingsAccount();
        }
    }
    internal class CurrentAccountFactory : AccountFactory
    {
        public override Account Create()
        {
            return new CurrentAccount();
        }
    }

    internal class FixedDepositAccountFactory : AccountFactory
    {
        public override Account Create()
        {
            return new FixedDepositAccount();
        }
    }
}
