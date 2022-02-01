using System;
using System.Collections.Generic;
namespace LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            var invoice1 = new LocalInvoice();
            var invoice2 = new InterStateInvoice();
            var invoice3 = new LocalInvoice();

            var Invoices = new List<Invoice>() { invoice1, invoice2, invoice3 };
            //Invoices.Add(new Quotation());
            foreach(var invoice in Invoices)
            {
                invoice.CalculateTax();
                ((ISavableInvoice)invoice).Save();
            }
        }
    }
}
