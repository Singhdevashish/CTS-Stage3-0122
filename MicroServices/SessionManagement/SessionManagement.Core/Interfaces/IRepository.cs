using SessionManagement.Core.Entitites;
using SessionManagement.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SessionManagement.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T item);
        T Remove(T item);
        T Update(T item);
        Task<int> SaveAsync();
        IReadOnlyCollection<T> Get(BaseSpecification<T> spec);
    }
}
