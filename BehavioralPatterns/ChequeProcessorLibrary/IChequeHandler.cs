using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeProcessorLibrary
{
    public interface IChequeHandler
    {
        ChequeStatus ProcessCheque(Cheque cheque);
        void Next(IChequeHandler handler);
    }
}
