﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Specifications;

namespace TalabatG02.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);

        Task<T> GetByIdWithSpecAsync(ISpecification<T> spec);

        Task<int> GetCountBySpecAsync(ISpecification<T> spec);
        
        Task Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
