using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    interface IDatabaseOperations
    {
        void Save();
        void Read();    
    }
    interface IDatabaseOperationsV1
    {
        void Delete();
    }

    class CustomerManager : IDatabaseOperations
    {
        public void Read()
        {
            Console.WriteLine("Reading customer");
        }

        public void Save()
        {
            Console.WriteLine("Saving customer");
        }
    }

    class InvoiceManger : IDatabaseOperations, IDatabaseOperationsV1
    {
        public void Delete()
        {
            Console.WriteLine("Deleting invoice");
        }

        public void Read()
        {
            Console.WriteLine("Reading invoice");
        }

        public void Save()
        {
            Console.WriteLine("Saving invoice");
        }
    }
}
