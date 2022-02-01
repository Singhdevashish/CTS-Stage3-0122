using System;

namespace InvoiceManagementLib
{

    public class ExportInvoice : Invoice
    {
        public override void PrintDetails()
        {
            Console.WriteLine("Printing export invoice");
        }

        public override void SaveAs(string fileName)
        {
            Console.WriteLine("This is export invoice with export duty added", fileName);
        }
    }
}
