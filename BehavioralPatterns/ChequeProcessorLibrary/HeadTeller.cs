using System;

namespace ChequeProcessorLibrary
{
    public class HeadTeller : Employee
    {
        public HeadTeller(string name) : base(name)
        {

        }
        public override ChequeStatus ClearCheque(Cheque cheque)
        {
            Console.WriteLine("HeadTeller : " + Name);

            if (cheque.Amount > 100000)
                return ChequeStatus.ApprovalRequired;
            return ChequeStatus.Cleared;
        }
    }
   

}
