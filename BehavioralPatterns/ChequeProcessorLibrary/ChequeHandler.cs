using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessorLibrary
{
    public class ChequeHandler : IChequeHandler
    {
        private Employee receiver;
        private IChequeHandler nextHandler;
        public ChequeHandler(Employee receiver)
        {
            this.receiver = receiver;
        }
        public void Next(IChequeHandler handler)
        {
            this.nextHandler = handler;
        }

        public ChequeStatus ProcessCheque(Cheque cheque)
        {
            Console.WriteLine("Receiver : {0}", receiver.Name);
            var status = receiver.ClearCheque(cheque);
            if (status == ChequeStatus.ApprovalRequired && nextHandler!=null)
                nextHandler.ProcessCheque(cheque);
            return status;
        }
    }
}
