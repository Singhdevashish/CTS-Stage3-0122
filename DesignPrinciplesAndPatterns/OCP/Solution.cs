using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    class Invoice
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double TaxAmount { get; set; }
        public double NetAmount { get; set; }


        public virtual void CalculateTaxes()
        {
            NetAmount = Amount + TaxAmount;
        }
    }
    class LocalInvoice : Invoice
    {
        public override void CalculateTaxes()
        {
            TaxAmount = (Amount * 0.015);
            base.CalculateTaxes();
        }
    }
    class InterstateInvoice : Invoice
    {
        public override void CalculateTaxes()
        {
            TaxAmount = (Amount * 0.025);
            base.CalculateTaxes();
        }
    }

    class InternationInvoice : Invoice
    {
        public override void CalculateTaxes()
        {
            TaxAmount = (Amount * 0.050);
            base.CalculateTaxes();
        }
    }
}
