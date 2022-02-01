using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPDemo
{
    interface IDatabaseOperations_ISP
    {
        void Save();
        void Read();      
    }
    interface IDatabaseDeleteOperation
    {
        void Delete();
        
    }
    interface IExport
    {
        void Export();
    }
    class CustomerManager_ISP : IDatabaseOperations_ISP
    {
        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }

    class InvoiceManger_ISP : IDatabaseOperations_ISP, IDatabaseDeleteOperation, IExport
    {
        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Export()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
