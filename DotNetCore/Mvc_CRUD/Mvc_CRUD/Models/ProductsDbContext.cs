using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
namespace Mvc_CRUD.Models
{
    public class ProductsDbContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options): base(options)
        {

        }
    }
}
