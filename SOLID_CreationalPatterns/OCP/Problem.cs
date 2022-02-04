//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OCP
//{
//    class Invoice
//    {
//        public int Id { get; set; }
//        public double Amount { get; set; }
//        public double TaxAmount { get; set; }
//        public double NetAmount { get; set; }

//        public string InvoiceType { get; set; }

//        public void CalculateTaxes()
//        {
//            switch (InvoiceType)
//            {
//                case "Local":
//                    TaxAmount = (Amount * 0.015);
//                    break;
//                case "InterState":
//                    TaxAmount = (Amount * 0.025);
//                    break;
//                default:
//                    TaxAmount = 0;
//                    break;
//            }
//            NetAmount = Amount + TaxAmount;
//        }
//    }
//}
