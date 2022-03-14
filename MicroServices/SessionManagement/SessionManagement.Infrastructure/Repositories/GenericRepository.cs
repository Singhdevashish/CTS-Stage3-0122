using Microsoft.EntityFrameworkCore;
using SessionManagement.Core.Entitites;
using SessionManagement.Core.Interfaces;
using SessionManagement.Core.Specifications;
using SessionManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionManagement.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SessionManagementContext context;
        public GenericRepository(SessionManagementContext context)
        {
            this.context = context;
        }
        public IReadOnlyCollection<T> Get(BaseSpecification<T> spec)
        {
            var Data = context.Set<T>().AsQueryable();

            //foreach (var include in spec.Includes)
            //    Data = Data.Include(include);
            var DataWithIncludes = spec.Includes.Aggregate(Data, (current, inc) => current.Include(navigationPropertyPath: inc));
            return DataWithIncludes
                            .Where(spec.ToExpression().Compile())
                            .ToList();
        }
        public T Add(T item)
        {
            return context.Add(item).Entity;
        }
        public T Remove(T item)
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

    }
}
