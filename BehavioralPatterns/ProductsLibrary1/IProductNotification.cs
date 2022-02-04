using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsLibrary1
{
    public interface IProductNotification
    {
        void Attach(Customer customer);
        void Detach(Customer customer);
        void Notify();
    }
}
