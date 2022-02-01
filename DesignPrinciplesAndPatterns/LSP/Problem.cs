//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LSP
//{
//    abstract class Invoice
//    {
//        public abstract void CalculateTax();
//        public abstract void Save();
//    }
   

//    class LocalInvoice : Invoice
//    {
//        public override void CalculateTax()
//        {
//            Console.WriteLine("Calculating tax for local invoice");
//        }

//        public override void Save()
//        {
//            Console.WriteLine("Saving local invoice");
//        }
//    }

//    class InterStateInvoice : Invoice
//    {
//        public override void CalculateTax()
//        {
//            Console.WriteLine("Calculating tax for interstate invoice");
//        }

//        public override void Save()
//        {
//            Console.WriteLine("Saving interstate invoice");
//        }
//    }

//    class Quotation : Invoice
//    {
//        public override void CalculateTax()
//        {
//            throw new NotImplementedException();
//        }

//        public override void Save()
//        {
//            Console.WriteLine("Saving quotation");
//        }
//    }
//}
