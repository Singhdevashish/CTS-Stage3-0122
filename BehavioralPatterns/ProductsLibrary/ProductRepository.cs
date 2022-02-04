using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsLibrary
{
    public class ProductRepository : IProductRepository
    {
        static List<Product> Products = new List<Product>();
        public void Add(Product product)
        {
            Products.Add(product);
        }

        public void Delete(int id)
        {
            int index = Products.FindIndex(p => p.Id == id);
            Products.RemoveAt(index);
        }

        public IEnumerable<Product> GetAll()
        {
            return Products.ToList();
        }

        public Product GetById(int id)
        {
            return Products.Find(p => p.Id == id);
        }
    }
}
