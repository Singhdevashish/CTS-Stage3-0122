using System.Collections.Generic;

namespace ProductsLibrary
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Delete(int id);
        Product GetById(int id);
    }
}
