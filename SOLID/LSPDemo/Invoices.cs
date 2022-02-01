using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPDemo
{
    abstract class Invoice
    {
        public abstract void CalculateTax();
        public abstract void Save();
    }

    class LocalInvoice : Invoice
    {
        public override void CalculateTax()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }

    class InterStateInvoice : Invoice
    {
        public override void CalculateTax()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }

    class Quotation : Invoice
    {
        public override void CalculateTax()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
