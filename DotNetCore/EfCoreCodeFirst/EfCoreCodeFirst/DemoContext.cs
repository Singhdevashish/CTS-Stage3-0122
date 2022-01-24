using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
namespace EfCoreCodeFirst
{
    public class DemoContext : DbContext
    {
        public DemoContext()
        {

        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=(localdb)\\mssqllocaldb;database=ADM21DF014.EFCORE.DEMO; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(p => p.EmployeeCode);
        }
    }
}
