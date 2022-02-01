using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPDemo
{
    class Invoice_OCP
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

    class LocalInvoice : Invoice_OCP
    {
        public override void CalculateTaxes()
        {
            TaxAmount = (Amount * 0.015);
            base.CalculateTaxes();
        }
    }

    class InterStateInvoice : Invoice_OCP
    {
        public override void CalculateTaxes()
        {
            TaxAmount = (Amount * 0.025);
            base.CalculateTaxes();
        }
    }
}
