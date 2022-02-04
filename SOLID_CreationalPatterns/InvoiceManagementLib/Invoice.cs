namespace InvoiceManagementLib
{
    public abstract class Invoice
    {
        public abstract void PrintDetails();
        public abstract void SaveAs(string fileName);
    }
}
