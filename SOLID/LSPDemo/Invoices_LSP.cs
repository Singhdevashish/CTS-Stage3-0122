using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPDemo
{
    interface IDatabaseOperations
    {
        void Save();
    }
    abstract class Invoice_LSP
    {
        public abstract void CalculateTax();
        
    }

    class LocalInvoice_LSP : Invoice_LSP, IDatabaseOperations
    {
        public override void CalculateTax()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }

    class InterStateInvoice_LSP : Invoice_LSP, IDatabaseOperations
    {
        public override void CalculateTax()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }

    class Quotation_LSP : Invoice_LSP
    {
        public override void CalculateTax()
        {
            throw new NotImplementedException();
        }

        
    }
}
