using System;

namespace ChequeProcessorLibrary
{
    public class Teller : Employee
    {
        public Teller(string name) : base(name)
        {

        }
        public override ChequeStatus ClearCheque(Cheque cheque)
        {
            Console.WriteLine("Teller : " + Name);
            if (cheque.Amount > 50000)
                return ChequeStatus.ApprovalRequired;
            return ChequeStatus.Cleared;
        }
    }
   

}
