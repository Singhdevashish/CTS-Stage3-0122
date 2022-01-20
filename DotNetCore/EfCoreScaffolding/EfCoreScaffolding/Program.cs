using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreScaffolding.Database;
using Microsoft.EntityFrameworkCore;

namespace EfCoreScaffolding
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var data = await ShowAll();
            foreach (var item in data)
                Console.WriteLine($"Id={item.Id}, \tName={item.Name}");

            int rows = await AddNew();
            Console.WriteLine($"{rows} added");

             data = await ShowAll();
            foreach (var item in data)
                Console.WriteLine($"Id={item.Id}, \tName={item.Name}");
        }

        static async Task<List<Employee>> ShowAll()
        {
            var context = new EmpDbContext();
            var query = from obj in context.Employee
                        select obj;


            return await query.ToListAsync();
        }
        static async Task<int> AddNew()
        {
            var e = new Employee();
            Console.WriteLine("Enter employee name");
            e.Name = Console.ReadLine();

            var context = new EmpDbContext();
            context.Employee.Add(e);
            return await context.SaveChangesAsync();
            
        }
    }
}
