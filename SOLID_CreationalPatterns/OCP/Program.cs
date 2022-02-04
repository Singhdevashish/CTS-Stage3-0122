using System;

namespace OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            //var invoice = new Invoice
            //{
            //    Id = 101, Amount = 10000
            //};
            //invoice.InvoiceType = "Local";
            //invoice.CalculateTaxes();
            //Console.WriteLine(invoice.NetAmount + "\t" + invoice.TaxAmount);


            //var invoice1 = new Invoice
            //{
            //    Id = 102,
            //    Amount = 10000
            //};
            //invoice1.InvoiceType = "InterState";
            //invoice1.CalculateTaxes();
            //Console.WriteLine(invoice1.NetAmount + "\t" + invoice1.TaxAmount);


            var invoice = new LocalInvoice
            {
                Id = 101,
                Amount = 10000
            };
            invoice.CalculateTaxes();
            Console.WriteLine(invoice.NetAmount + "\t" + invoice.TaxAmount);


            var invoice1 = new InterstateInvoice
            {
                Id = 102,
                Amount = 10000
            };
            invoice1.CalculateTaxes();
            Console.WriteLine(invoice1.NetAmount + "\t" + invoice1.TaxAmount);
        }
    }
}
