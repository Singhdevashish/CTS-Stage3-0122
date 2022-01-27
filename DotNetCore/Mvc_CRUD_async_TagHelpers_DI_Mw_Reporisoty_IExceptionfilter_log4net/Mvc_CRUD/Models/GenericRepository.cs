using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_CRUD.Models
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ProductsDbContext context;
        public GenericRepository(ProductsDbContext ctx)
        {
            this.context = ctx;
        }

        public T Add(T item)
        {
            return context.Add(item).Entity;
        }

        public T Delete(T item)
        {
            return context.Remove(item).Entity;
        }

        public T Update(T item)
        {
            return context.Update(item).Entity;
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> condition = null)
        {
            if (condition == null)
                return await context.Set<T>().ToListAsync();

            return await context.Set<T>().Where(condition).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

      

       
    }
}
