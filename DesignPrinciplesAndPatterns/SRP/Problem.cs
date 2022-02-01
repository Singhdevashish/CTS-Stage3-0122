//using System;

//namespace SRP
//{
//    public class Order
//    {
//        public int OrderId { get; set; }
//        public DateTime OrderDate { get; set; }
//        public double Amount { get; set; }
//        public string Status { get; set; }

//        public void Confirm()
//        {
//            this.Status = "Confirmed";
//            Console.WriteLine($"Order {OrderId} is confirmed");
//        }
//        public void Cancel()
//        {
//            this.Status = "Cancel";
//            Console.WriteLine($"Order {OrderId} is cancelled");
//            Console.WriteLine($"Order amount {Amount} will be refunded to your account");
//        }
//        public void Save()
//        {
//            //ADO.NET Code to save order in database
//            //1. Create connection
//            //2. Create an insert query
//            //3. Create command
//            //4. Open connection
//            //5. Execute query
//            //6. Close connection
//        }
//    }
//}
