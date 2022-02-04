using System;

namespace ProductsLibrary1
{


    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public void Notify(Product product)
        {
            Console.WriteLine($"{this.Name} received notification for product {product.Name}");
        }
    }
}
