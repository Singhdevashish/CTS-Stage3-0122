using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPi_CRUD.Models
{
    public class GenereicRepository<T> : IRepository<T> where T: class
    {
        private readonly ADM21DF014MVCCRUDContext context;
        public GenereicRepository(ADM21DF014MVCCRUDContext context)
        {
            this.context = context;
        }
      
        public T Add(T item)
        {
            return context.Add(item).Entity;
        }
        public T Update(T item)
        {
            return context.Update(item).Entity;
        }
        public T Delete(T item)
        {
            return context.Remove(item).Entity;
        }
        public IReadOnlyList<T> Get(Expression<Func<T, bool>> condition = null)
        {
            var Entities = context.Set<T>();
            if (condition != null)
                return Entities.Where(condition).ToList();
            return Entities.ToList();
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
