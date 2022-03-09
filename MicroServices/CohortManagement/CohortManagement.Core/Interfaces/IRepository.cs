using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CohortManagement.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        T Add(T item);
        T Remove(T item);
        T Update(T item);
        Task<int> SaveAsync();
        Task<IReadOnlyCollection<T>> GetAsync();
    }
}
