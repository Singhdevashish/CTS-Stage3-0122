﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainerManagement.Domain
{
    public interface IRepository<T> where T : class
    {
        T Add(T item);
        T Update(T item);
        T Delete(T item);
        Task<IReadOnlyCollection<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task<int> SaveAsync();
    }
}
