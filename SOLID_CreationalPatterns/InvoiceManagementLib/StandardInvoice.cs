using System;

namespace InvoiceManagementLib
{
    public class StandardInvoice : Invoice
    {
        public override void PrintDetails()
        {
            Console.WriteLine("Printing standard invoice");
        }

        public override void SaveAs(string fileName)
        {
            Console.WriteLine("This is standard invoice", fileName);
        }
    }
}
