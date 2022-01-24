using System;
using Microsoft.EntityFrameworkCore;
namespace EFCoreCodeFirst02
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options): base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ContextOptions = new DbContextOptionsBuilder<ProductContext>();
            ContextOptions.UseSqlServer("");

            var Context = new ProductContext(ContextOptions.Options);

        }
    }
}
