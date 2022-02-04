using System;
using InvoiceManagementLib;
namespace InvoiceManagementLibClient
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardInvoice invoice1 = new StandardInvoice();
            invoice1.PrintDetails();
            invoice1.SaveAs("Invoice1.pdf");

            ExportInvoice invoice2 = new ExportInvoice();
            invoice2.PrintDetails();
            invoice2.SaveAs("Invoice2.pdf");
        }
    }
}
