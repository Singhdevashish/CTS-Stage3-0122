using System;

namespace ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabaseOperations invoiceOp = new InvoiceManger();
            invoiceOp.Save();
            invoiceOp.Read();
            IDatabaseOperationsV1 Deletable = invoiceOp as IDatabaseOperationsV1;
            Deletable.Delete();

            IDatabaseOperations custOp = new CustomerManager();
            custOp.Read();
            custOp.Save();
        }
    }
}
