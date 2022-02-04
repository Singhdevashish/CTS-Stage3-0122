using System;
using ChequeProcessorLibrary;
namespace ChequeProcessorLibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var cheque = new Cheque
            {
                ChequeNo = "101",
                PayeeName = "Syed",
                Amount = 25000
            };
            var teller = new Teller("Jojo");
            var headteller = new HeadTeller("Sarah");
            var assistantManager = new AssistantManager("Sam");
            var manager = new Manager("Elisa");
            #region ChequeProcessingLogic
            //if (teller.ClearCheque(cheque) == ChequeStatus.Cleared)
            //{
            //    Console.WriteLine($"Cheque {cheque.ChequeNo} is cleared by {teller.Name}");
            //}
            //else
            //{
            //    if (headteller.ClearCheque(cheque) == ChequeStatus.Cleared)
            //    {
            //        Console.WriteLine($"Cheque {cheque.ChequeNo} is cleared by {headteller.Name}");
            //    }
            //    else
            //    {
            //        if (assistantManager.ClearCheque(cheque) == ChequeStatus.Cleared)
            //        {
            //            Console.WriteLine($"Cheque {cheque.ChequeNo} is cleared by {assistantManager.Name}");
            //        }
            //        else
            //        {
            //            if (manager.ClearCheque(cheque) == ChequeStatus.Cleared)
            //            {
            //                Console.WriteLine($"Cheque {cheque.ChequeNo} is cleared by {manager.Name}");
            //            }
            //            else
            //            {
            //                Console.WriteLine("Cheque cannot be cleared");
            //            }
            //        }
            //    }
            //}
            #endregion

            var handler1 = new ChequeHandler(teller);
            var handler2 = new ChequeHandler(headteller);
            var handler3 = new ChequeHandler(assistantManager);
            var handler4 = new ChequeHandler(manager);

            handler1.Next(handler2);
            handler2.Next(handler3);
            handler3.Next(handler4);

            var status = handler1.ProcessCheque(cheque);
            Console.WriteLine("Cheque status : {0}", status);

        }
    }
}
