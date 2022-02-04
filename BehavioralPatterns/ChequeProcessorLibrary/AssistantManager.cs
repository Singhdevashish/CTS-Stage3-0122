using System;

namespace ChequeProcessorLibrary
{
    public class AssistantManager : Employee
    {
        public AssistantManager(string name) : base(name)
        {

        }
        public override ChequeStatus ClearCheque(Cheque cheque)
        {
            Console.WriteLine("Assistant Manager : " + Name);

            if (cheque.Amount > 1000000)
                return ChequeStatus.ApprovalRequired;
            return ChequeStatus.Cleared;
        }
    }
   

}
