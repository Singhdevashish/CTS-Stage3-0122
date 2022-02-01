using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib1
{
    public abstract class Account
    {
        protected double balance;
        public double GetBalance()
        {
            return balance;
        }
        public abstract void Withdraw(double amount);
        public abstract void Deposit(double amount);

    }


}
