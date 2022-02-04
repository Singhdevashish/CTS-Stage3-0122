using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeProcessorLibrary
{
    public class Manager : Employee
    {
        public Manager(string name) : base(name)
        {

        }
        public override ChequeStatus ClearCheque(Cheque cheque)
        {
            Console.WriteLine("Manager : " + Name);
            return ChequeStatus.Cleared;
        }
    }
}
