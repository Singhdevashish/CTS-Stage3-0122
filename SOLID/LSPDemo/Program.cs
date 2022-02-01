using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var Invoices = new List<Invoice>();
            Invoices.Add(new LocalInvoice());
            Invoices.Add(new InterStateInvoice());
            Invoices.Add(new InterStateInvoice());
            Invoices.Add(new InterStateInvoice());
            Invoices.Add(new InterStateInvoice());
            Invoices.Add(new LocalInvoice());
            Invoices.Add(new Quotation());

            foreach(var invoice in Invoices)
            {
                invoice.Save();
            }
        }
    }
}
