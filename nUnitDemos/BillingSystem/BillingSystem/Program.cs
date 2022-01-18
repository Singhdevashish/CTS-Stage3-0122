using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
    }
    public class Customer
    {
        public string Email { get; set; }
    }
    public class InvoiceManager
    {
        IEmailSender emailSender;
        public InvoiceManager(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }
        public bool ConfirmInvoice(Invoice invoice, Customer customer)
        {
            Console.WriteLine("Invoice confirmed : {0}", invoice.InvoiceId);
            emailSender.SendEmail(customer.Email, "Your invoice confirmed. ID = " + invoice.InvoiceId);
            return  emailSender.SendEmail(customer.Email, "Your invoice confirmed. ID = " + invoice.InvoiceId);
           // return true;
        }
    }

    public interface IEmailSender
    {
        bool SendEmail(string toAddress, string message);
    }
    public class GmailSender : IEmailSender
    {
        public bool SendEmail(string toAddress, string message)
        {
            Console.WriteLine("Sending email to {0}\nMessage : {1}", toAddress, message);
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           

            var invoice = new Invoice { InvoiceId = 101 };
            var customer = new Customer { Email = "techiesyed@outlook.com" };

            IEmailSender emailSender = new GmailSender();
            var invoiceManager = new InvoiceManager(emailSender);
            bool result = invoiceManager.ConfirmInvoice(invoice, customer);
            Console.ReadKey();
        }
    }
}
