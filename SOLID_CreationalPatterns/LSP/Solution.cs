using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
    abstract class Invoice
    {
        public abstract void CalculateTax();
       
    }
    
    interface ISavableInvoice
    {
        void Save();
    }

    class LocalInvoice : Invoice, ISavableInvoice
    {
        public override void CalculateTax()
        {
            Console.WriteLine("Calculating tax for local invoice");
        }

        public void Save()
        {
            Console.WriteLine("Saving local invoice");
        }
    }

    class InterStateInvoice : Invoice, ISavableInvoice
    {
        public override void CalculateTax()
        {
            Console.WriteLine("Calculating tax for interstate invoice");
        }

        public void Save()
        {
            Console.WriteLine("Saving interstate invoice");
        }
    }

    class Quotation : ISavableInvoice
    {
        public void Save()
        {
            Console.WriteLine("Saving quotation");
        }
    }
}
